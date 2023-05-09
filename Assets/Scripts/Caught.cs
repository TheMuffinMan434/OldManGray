using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Caught : MonoBehaviour
{
    public bool caught;
    public GameObject caughtUI;
    public Image background;
    public Color color;
    public SceneManagement scenes;

    void Start()
    {
        caughtUI.SetActive(false);
        color.a = 1;
        background.color = color;
        background.CrossFadeAlpha(0f, 0f, true);
    }

    void Update()
    {
        if (caught)
        {
            if (scenes.isFishing)
                scenes.CloseFishing();
            caughtUI.SetActive(true);
            FadeToBlack(background, 1f, .5f, delegate { scenes.LoadMenu(); });
        }
    }

    void FadeToBlack(Image image, float alpha, float duration, System.Action action)
    {
        StartCoroutine(CrossFadeAlpha(image, alpha, duration, action));
    }

    IEnumerator CrossFadeAlpha(Image image, float alpha, float duration, System.Action action)
    {
        image.CrossFadeAlpha(alpha, duration, false);
        yield return new WaitForSeconds(5);
        action.Invoke();
    }
}
