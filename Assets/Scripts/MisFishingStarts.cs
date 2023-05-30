using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MisFishingStarts : MonoBehaviour
{
    public KeyCodeInfo[] possibleKeys;
    private void Start()
    {
        foreach (KeyCodeInfo keyCodeInfo in possibleKeys)
            keyCodeInfo.inUse = false;
    }
}
