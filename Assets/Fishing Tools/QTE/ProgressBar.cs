using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    [Range(0,100)]
    public int points;

    public Image progressBar;
    public ProgressBarPoint progress;

    private void Start()
    {
        points = 0;
    }


    void Update()
    {
        /*if (progress.points < 0)progress.points = 0;*/
        if (progress.points > 100) progress.points = 100;
        UpdateProgress();
        points = progress.points;
    }

    public void UpdateProgress()
    {
        float fillVal = (float)points / 100;
        progressBar.fillAmount = fillVal;
    }
}
