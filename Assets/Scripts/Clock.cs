using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Clock : MonoBehaviour
{
    public TMP_Text clockText;
    public DayEnd dayEndScript;
    float time;
    float hour;
    float min;
    string fullTime;
    string pm = "PM";

    void Start()
    {
        clockText.text = "1:00 AM"; 
    }

    void Update()
    {
        UpdateTime();
    }
    
    public void UpdateTime()
    {
        time += Time.deltaTime;
        hour = time / 60;
        min = time % 60;

        hour = Mathf.FloorToInt(hour) + 1;
        min = Mathf.FloorToInt(min);

        /*UpdateAMPM();*/

        if (min < 10)
            fullTime = hour.ToString() + ":0" + min.ToString() + pm;
        else
            fullTime = hour.ToString() + ":" + min.ToString() + pm;

        clockText.text = fullTime;

        if (hour == 5) ClosingTime();
    }

    public void ClosingTime()
    {
        dayEndScript.dayEnd = true;
    }

    

}
