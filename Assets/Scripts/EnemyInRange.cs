using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyInRange : MonoBehaviour
{
    /*public FieldofView fov;*/
    public Image exclamation;
    void Start()
    {
        /*fov = GameObject.FindGameObjectWithTag("Enemy").*/
        exclamation.enabled = false;
    }

    void Update()
    {
       /* if (fov.lookForPlayer)
        {
            exclamation.enabled = true;
        }
        else
            exclamation.enabled = false;*/
    }
}
