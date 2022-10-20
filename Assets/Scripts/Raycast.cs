using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Raycast : MonoBehaviour
{
    public GameObject fButton;
    bool hitInRange;
    void Start()
    {

    }
    void Update()
    {
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        Physics.Raycast(transform.position, fwd, out RaycastHit hit);
        hitInRange = hit.distance <= 5;

        if(hit.collider.CompareTag("Fishing")){
            fButton.SetActive(true);
        }
        else
        {
            fButton.SetActive(false);
        }
        
    }
}
