using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QTEKeys : MonoBehaviour
{
    public KeyCodeInfo[] possibleKeys;
    KeyCode thisKey;
    public Button button;
    public TMP_Text text;
    private int index;

    private void Awake()
    {
        GetThisKeyCode();
        button.interactable = false;

    }

    private void Update()
    {
        if (Input.GetKeyDown(thisKey))
            Click();
    }

    public void GetThisKeyCode()
    {
        index = Random.Range(0, possibleKeys.Length);
        if (!possibleKeys[index].inUse)
        {
            thisKey = possibleKeys[index].keyCode;
            text.text = possibleKeys[index].KeyCodeText;
            possibleKeys[index].inUse = true;
        }
        else GetThisKeyCode();
    }

    public void Click()
    {
        button.onClick.Invoke();
        possibleKeys[index].inUse = false;
    }
}
