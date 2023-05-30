using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiscReset : MonoBehaviour
{
    public FishingScore score;
    public SceneManagement sManagment;
    public ProgressBarPoint progressBar;
    private void Start()
    {
        score.fishingScore = 0;
    }

    private void Update()
    {
        FishingProg();
    }

    public void FishingProg()
    {
        if (!sManagment.isFishing) progressBar.points = 0;
    }
}
