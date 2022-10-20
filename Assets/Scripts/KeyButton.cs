using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class KeyButton : MonoBehaviour
{
    public KeyCode key;

    public Button button { get; private set; }

    Graphic targetGraphic;
    Color normalColor;

    void Awake()
    {
        button = GetComponent<Button>();
        button.interactable = false;
        targetGraphic = GetComponent<Graphic>();

        ColorBlock cb = button.colors;
        cb.disabledColor = cb.normalColor;
        button.colors = cb;
    }

    private void Start()
    {
        button.targetGraphic = null;
        Up();
    }


    void Update()
    {
        if (Input.GetKeyDown(key))
            Down();
        else if (Input.GetKeyUp(key))
            Up();
        
    }

    void Up()
    {
        StartColorTween(button.colors.normalColor, false);
    }

    void Down()
    {
        StartColorTween(button.colors.pressedColor, false);
        button.onClick.Invoke();
    }

    void StartColorTween(Color targetColor, bool instant)
    {
        if (targetGraphic == null)
            return;

        targetGraphic.CrossFadeColor(targetColor, instant ? 0f : button.colors.fadeDuration, true, true);
    }

    private void OnApplicationFocus(bool focus)
    {
        Up();
    }
}
