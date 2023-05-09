using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Clock : MonoBehaviour
{
    public TMP_Text clockText;
    float time;
    float hour;
    float min;
    string fullTime;
    string amPm;

    void Start()
    {
        amPm = "AM";
        clockText.text = "10:00 AM"; 
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

        hour = Mathf.FloorToInt(hour);
        min = Mathf.FloorToInt(min);

        UpdateAMPM();

        if (min < 10)
            fullTime = hour.ToString() + ":0" + min.ToString() + amPm;
        else
            fullTime = hour.ToString() + ":" + min.ToString() + amPm;

        clockText.text = fullTime;
    }

    public void UpdateAMPM()
    {
        if (amPm == "AM")
        {
            hour += 10;
            if (hour == 12 && min == 1)
                amPm = "PM";
        }
    }

}
