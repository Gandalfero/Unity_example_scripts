using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CodeLock : MonoBehaviour
{
    string code;
    [SerializeField]
    Text codeText;
    [SerializeField]
    GameObject locker;
    [SerializeField]
    Text doorOpened;
    [SerializeField]
    Text codeWrong;
    [SerializeField]
    GameObject lockUI;
    [SerializeField]
    GameObject note;

    string goodCode = "1993";
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        codeText.text = code;
        NumLock();
    }
    void DoorText()
    {
        doorOpened.enabled = false;
    }
    void WrongCodeText()
    {
        codeWrong.enabled = false;
    }

    void NumLock()
    {
        if ((Input.GetKeyDown(KeyCode.Keypad1))|| (Input.GetKeyDown(KeyCode.Alpha1)))
        {
            code = code + "1";
        }
        if ((Input.GetKeyDown(KeyCode.Keypad2)) || (Input.GetKeyDown(KeyCode.Alpha2)))
        {
            code = code + "2";
        }
        if ((Input.GetKeyDown(KeyCode.Keypad3)) || (Input.GetKeyDown(KeyCode.Alpha3)))
        {
            code = code + "3";
        }
        if ((Input.GetKeyDown(KeyCode.Keypad4)) || (Input.GetKeyDown(KeyCode.Alpha4)))
        {
            code = code + "4";
        }
        if ((Input.GetKeyDown(KeyCode.Keypad5)) || (Input.GetKeyDown(KeyCode.Alpha5)))
        {
            code = code + "5";
        }
        if ((Input.GetKeyDown(KeyCode.Keypad6)) || (Input.GetKeyDown(KeyCode.Alpha6)))
        {
            code = code + "6";
        }
        if ((Input.GetKeyDown(KeyCode.Keypad7)) || (Input.GetKeyDown(KeyCode.Alpha7)))
        {
            code = code + "7";
        }
        if ((Input.GetKeyDown(KeyCode.Keypad8)) || (Input.GetKeyDown(KeyCode.Alpha8)))
        {
            code = code + "8";
        }
        if ((Input.GetKeyDown(KeyCode.Keypad9)) || (Input.GetKeyDown(KeyCode.Alpha9)))
        {
            code = code + "9";
        }
        if ((Input.GetKeyDown(KeyCode.Keypad0)) || (Input.GetKeyDown(KeyCode.Alpha0)))
        {
            code = code + "0";
        }
        if ((Input.GetKeyDown(KeyCode.KeypadEnter))||(Input.GetKeyDown(KeyCode.Return)))
        {
            if (goodCode == code)
            {
                gameObject.SetActive(false);
                locker.GetComponent<BoxCollider>().enabled = false;
                doorOpened.enabled = true;
                Invoke("doorText", 2f);
                Object.Destroy(note);
                GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().note1Taken = false;
                GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().door1CanBeOpen = true;

            }
            else
            {
                code = null;
                codeWrong.enabled = true;
                Invoke("WrongCodeText", 2f);
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            lockUI.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Delete))
        {
            code = null;
        }
    }
}
