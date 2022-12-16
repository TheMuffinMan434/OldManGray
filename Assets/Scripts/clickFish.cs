using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class clickFish : MonoBehaviour
{
    public static Vector2 mousePosition;
    public GameObject fishBeacon;
    public GetMousePosition getMouse;
    public bool fishBeaconOn;
    public bool bite;
    void Start()
    {
        fishBeacon.SetActive(false);
        fishBeaconOn = false;
        bite = false;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            LetsFish();
            /*getMouse.leftClick = true;*/
        }
            
    }

    public void LetsFish()
    {
        mousePosition = Input.mousePosition;
        fishBeacon.transform.position = mousePosition;
        if (!fishBeaconOn)
        {
            fishBeacon.SetActive(true);
            fishBeaconOn = true;
        }
        /*if (fishBeacon && bite)
        {
            ItsDinnerTime();
        }*/
        else
        {
            fishBeacon.SetActive(false);
            fishBeaconOn = false;
        }
    }

    public void ItsDinnerTime()
    {

    }
}
