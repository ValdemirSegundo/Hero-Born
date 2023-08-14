using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerBehavior : MonoBehaviour
{
    private GameBehavior _gameManager;
    public float moveSpeed = 10f;
    public float rotateSpeed = 75f;

    public float jumpVelocity = 5f;

    public float distanceToGround = 0.1f;

    public LayerMask groundLayer;

    public GameObject bullet;
    public float bulletSpeed = 100f;

    private float vInput; //vertical
    private float hInput; //horizontal
    private float MouseX;
    private float MouseY;

    public Vector3 verticalDirection;
    public Vector3 horizontalDirection;

    public Vector3 rotation;

    //1
    private Rigidbody _rb;

    private CapsuleCollider _col;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _col = GetComponent<CapsuleCollider>();
        _gameManager = GameObject.Find("GameManager").GetComponent<GameBehavior>();
        
    }

    // Update is called once per frame
    void Update()
    {

        if (IsGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            _rb.AddForce(Vector3.up * jumpVelocity, ForceMode.Impulse);
        }

        //Método tradicional
        /*
        vInput = Input.GetAxis("Vertical") * moveSpeed;
        hInput = Input.GetAxis("Horizontal") * rotateSpeed;
        */
        vInput = Input.GetAxis("Vertical");
        hInput = Input.GetAxis("Horizontal");

        //Exemplo utilizando Transform como movimentação padrão
        /*
        this.transform.Translate(Vector3.forward * vInput * Time.deltaTime);
        this.transform.Rotate(Vector3.up * hInput * Time.deltaTime);
        */

        if (Input.GetMouseButtonDown(0))
        {
            GameObject newBullet = Instantiate(bullet, this.transform.position + new Vector3(1, 0, 0), this.transform.rotation);
            Rigidbody bulletRB = newBullet.GetComponent<Rigidbody>();
            bulletRB.velocity = this.transform.forward * bulletSpeed;
        }
    }

    void FixedUpdate()
    {
        //Método Tradicional
        /*rotation = Vector3.up * hInput;

        Quaternion angleRot = Quaternion.Euler(rotation * Time.fixedDeltaTime); */

        //Método tradicional
        //_rb.MovePosition(this.transform.position + this.transform.forward * vInput * Time.fixedDeltaTime);

        MouseX = Input.GetAxis("Mouse X");
        MouseY = Input.GetAxis("Mouse Y");
        //Vector3 mouseAim = Camera.main.ScreenToWorldPoint(new Vector3(MouseX, MouseY, 0f));
        //Debug.Log(mouseAim);
        Quaternion angleRot = Quaternion.Euler(0f, MouseX, 0f );
        //Quaternion angleRot = Quaternion.Euler(mouseAim);


        _rb.MovePosition(this.transform.position + ((this.transform.forward * vInput * moveSpeed)  + (this.transform.right * hInput * rotateSpeed)) * Time.fixedDeltaTime);
        //Debug.Log(this.transform.forward * vInput);

        _rb.MoveRotation(_rb.rotation * angleRot);



        
    }

    private bool IsGrounded()
    {
        Vector3 capsuleBottom = new Vector3(_col.bounds.center.x, _col.bounds.min.y, _col.bounds.center.z);
        bool grounded = Physics.CheckCapsule(_col.bounds.center, capsuleBottom, distanceToGround, groundLayer, QueryTriggerInteraction.Ignore);

        return grounded;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Enemy")
        {
            _gameManager.HP -= 1;
        }
    }
}