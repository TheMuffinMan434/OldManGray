using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DayEnd : MonoBehaviour
{
    public bool dayEnd;
    public GameObject dayEndUI;
    public Image background;
    public TMP_Text displayScore;
    public FishingScore score;
    public Color color;
    public SceneManagement scenes;

    private void Start()
    {
        dayEnd = false;
        color.a = 1;
        background.color = color;
        background.CrossFadeAlpha(0f, 0f, true);
    }

    private void Update()
    {
        if (dayEnd)
        {
            if (scenes.isFishing) scenes.CloseFishing();
            dayEndUI.SetActive(true);
            displayScore.text = "Your Score: " + score.fishingScore.ToString();
            FadeToBlack(background, 1f, .5f);
        }
    }

    void FadeToBlack(Image image, float alpha, float duration)
    {
        StartCoroutine(CrossFadeAlpha(image, alpha, duration));
    }

    IEnumerator CrossFadeAlpha(Image image, float alpha, float duration)
    {
        image.CrossFadeAlpha(alpha, duration, false);
        yield return new WaitForSeconds(4);
        if (Input.anyKeyDown) scenes.LoadMenu();
    }
}
