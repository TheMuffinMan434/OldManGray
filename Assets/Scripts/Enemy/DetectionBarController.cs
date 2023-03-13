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
    public float time = 1;
    public Cupboard cupboard;

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
        }
        if (detectionLvl <= 0)
        {
            detectionLvl = 0;
            if (inView.lookForPlayer == true && !cupboard.inTheBoard)
            {
                time += Time.deltaTime;
                Debug.Log(Mathf.RoundToInt(time));
                if (Mathf.Round(time) % 3 == 0)
                {
                    inView.CallEnumerator();
                }
                /*StartCoroutine(WalkTimer());*/
            }
        }
    }

    public IEnumerator WalkTimer()
    {
        yield return new WaitForSeconds(3);
        inView.CallEnumerator();
    }
}
