using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using CustomExtensions;

public class GameBehavior : MonoBehaviour, IManager
{

    public string labelText = "Collect all 4 items and win your freedom!";
    public bool showWinScreen = false;
    public bool showLossScreen = false;
    public int maxItems = 4;
    private int _itemsCollected = 0;
    public int _playerHP = 10;
    

    public string _state;

    public string State
    {
        get { return State; }
        set { _state = value; }
    }

    public delegate void DebugDelegate(string newText);
    public DebugDelegate debug = Print;

    public void Initialize()
    {
        _state = "Manager initialized";
        _state.FancyDebug();
        
        debug(_state);

        LogWithDelegate(debug);
    }

    public int Items
    {
        get { return _itemsCollected; }

        set { 
            _itemsCollected = value;
            if(_itemsCollected >= maxItems)
            {
                labelText = "You've found all the items!";
                showWinScreen = true;
                Time.timeScale = 0f;
            }
            else
            {
                labelText = "Item found, only " + (maxItems - _itemsCollected) + " more to go!";
            }
            }
    }

    
    
    public int HP
    {
        get { return _playerHP; }

        set 
        {
            _playerHP = value;
            if (_playerHP <= 0)
            {
                labelText = "You want another life with that?";
                showLossScreen = true;
                Time.timeScale = 0;
            }
            else
            {
                labelText = "Ouch... That's got hurt.";
            }
            
            Debug.LogFormat("Lives: {0}", _playerHP);
            
        }
    }

    private void OnGUI()
    {
        GUI.Box(new Rect(20, 20, 500, 100), "Player Health: " + _playerHP);
        GUI.Box(new Rect(20, 50, 500, 100), "Items Collected: " + _itemsCollected);
        GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height - 50, 300, 50), labelText);

        if (showWinScreen)
        {
            if(GUI.Button(new Rect(Screen.width/2 - 100, Screen.height/2-50, 200, 100), "YOU WON!"))
            {
                Utilities.RestartLevel(0);
            }
        }

        if (showLossScreen)
        {
            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 50, 200, 100), "You lose..."))
            {
                Utilities.RestartLevel();
            }
        }
    }

    public static void Print(string newText)
    {
        Debug.Log(newText);
    }

    public void LogWithDelegate (DebugDelegate del)
    {
        del("Delegating the Debug Task");
    }

    // Start is called before the first frame update
    void Start()
    {
        Initialize();

        InventoryList<string> inventoryList = new InventoryList<string>();
        inventoryList.SetItem("Potion");
        Debug.Log(inventoryList.item);

        Cursor.lockState = CursorLockMode.Confined;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
