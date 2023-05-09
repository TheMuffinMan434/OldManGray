using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "KeyCodeInfo")]
public class KeyCodeInfo : ScriptableObject
{
    public KeyCode keyCode;
    public string KeyCodeText;
    public bool inUse;
}
