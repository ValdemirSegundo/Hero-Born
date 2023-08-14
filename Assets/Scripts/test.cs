using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public Camera cameraTest;
    private float XDirection;
    private float YDirection;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        cameraTest = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += transform.forward * speed * Time.deltaTime;
        XDirection += Input.GetAxis("Mouse X") * speed;
        YDirection += Input.GetAxis("Mouse Y") * speed;
        //cameraTest.transform.Rotate(new Vector3(XDirection, YDirection, cameraTest.transform.position.z));
        transform.eulerAngles = new Vector3(YDirection, XDirection, 0);
    }
}
