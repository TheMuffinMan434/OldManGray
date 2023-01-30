using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetectionBarController : MonoBehaviour
{
    public Image detectionBar;
    public float detectionLvl;
    public float maxDetection;
    public FieldofView inView;
    public bool found = false;
    public bool stillSus = true;
    private float time = 0;

    private void Update()
    {
        if (inView.canSeePlayer)
        {
            Sus();
        }
    }


    public void Sus()
    {
        if (detectionLvl < maxDetection)
        {
            detectionLvl += Time.deltaTime;
            detectionBar.fillAmount = detectionLvl / maxDetection;
        }
        if (detectionLvl >= maxDetection)
        {
            found = true;
        }

    }

    public void NotSus()
    {
        if (detectionLvl > 0)
        {
            detectionLvl -= Time.deltaTime;
            detectionBar.fillAmount = detectionLvl / maxDetection;
            time = 0;
        }
        if (detectionLvl <= 0)
        {
            detectionLvl = 0;
            time += Time.deltaTime;
        }
            
    }

}
