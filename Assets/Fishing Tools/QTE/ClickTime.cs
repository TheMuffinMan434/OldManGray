using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ClickTime : MonoBehaviour
{
    public GameObject clickCircle;
    public GameObject button;
    public ProgressBarPoint progress;
    public ButtonLocal buttonLocal;
    public Vector3 shrinkRate;
    public Vector3 minScale;
    public Vector3 deadScale;
    private string deadText;
    public TMP_Text deadTextDisplay;

    // max threshold
    public float maxGoodThresh;
    public float maxGreatThresh;
    public float maxPerfThresh;

    // min threshold
    public float minPerfThresh;
    public float minGreatThresh;
    public float minGoodThresh;

    private void Update()
    {
        ShrinkCircle();
        if (progress.points >= 100 || progress.points < 0) SucsessDestroy();
    }

    private void ShrinkCircle()
    {
        if (clickCircle.transform.localScale.x > minScale.x)
        {
            clickCircle.transform.localScale -= shrinkRate * Time.deltaTime;
        }
        else DestroyButton();
    }

    public void DestroyButton()
    {
        deadScale = clickCircle.transform.localScale;
        PointCalc(deadScale);
        deadTextDisplay.text = deadText;
        Destroy(button);
        /*RemoveButtonLocal(this.transform.position);*/
    }

    public void PointCalc(Vector3 deadScale)
    {
        if (deadScale.x <= maxGoodThresh && deadScale.x >= minGoodThresh)
        {
            if (deadScale.x <= maxGreatThresh && deadScale.x >= minGreatThresh)
            {
                if (deadScale.x <= maxPerfThresh && deadScale.x >= minPerfThresh)
                {
                    progress.points += 25;
                    deadText = "Perfect!";
                }
                else
                {
                    progress.points += 10;
                    deadText = "Great";
                }
            }
            else
            {
                progress.points -= 5;
                deadText = "ok";
            }
        }
        else
        {
            progress.points -= 15;
            deadText = "BAD";
        }
    }

    public void SucsessDestroy()
    {
        Destroy(button);
        /*RemoveButtonLocal(this.transform.position);*/
    }

    /*public void RemoveButtonLocal(Vector3 location)
    {
        buttonLocal.locations.Remove(location);
    }*/
}
