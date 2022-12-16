using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caught : MonoBehaviour
{
    public bool caught;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (caught)
        {
            Debug.Log("you got caught");
        }
    }
}
