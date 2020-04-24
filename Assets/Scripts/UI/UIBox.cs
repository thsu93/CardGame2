using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//UI Box in screen to display in-game messages

//To Do:
//Visual improvement necessary. 
//Setting Alpha likely not the proper way to do this.

public class UIBox : MonoBehaviour
{
    public Text messageText;
    public Text titleText;
    CanvasRenderer Drawer;
    GameManager manager;

    // Start is called before the first frame update
    void Start()
    {
        GameObject ManagerHolder = GameObject.Find("GameManager");
        manager = ManagerHolder.GetComponent<GameManager>();
    }

    // Update is called once per frame
    public void DisplayError(string errorText)
    {
        this.transform.SetAsLastSibling();
        messageText.text = errorText;
        messageText.fontSize = 100;
        messageText.color = Color.red;
    }

    public void DisplayMessage(string message)
    {
        messageText.text = message;
    }

    public void PressOK()
    {
        manager.StartGame();
        Destroy(this.gameObject);
    }


}   
