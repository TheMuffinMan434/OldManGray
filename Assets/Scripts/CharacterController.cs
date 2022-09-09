using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 current = this.transform.position;
        if (Input.GetKey(KeyCode.W))
        {  
            this.transform.position = current + new Vector3(.1f, 0f, 0f);
        }
        if (Input.GetKey(KeyCode.S))
        {
            this.transform.position = current - new Vector3(.1f, 0f, 0f);
        }
        if (Input.GetKey(KeyCode.A))
        {
            this.transform.position = current + new Vector3(0f, 0f, .1f);
        }
        if (Input.GetKey(KeyCode.D))
        {
            this.transform.position = current - new Vector3(0f, 0f, .1f);
        }
    }
}
