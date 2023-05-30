using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(TMP_Dropdown))]
public class DropdownKeyButton : MonoBehaviour
{
    public KeyCode fwdKey;
    public KeyCode backKey;

    public Hook hookScript;
    public GameObject hook;

    Graphic targetGraphic;
    public Bait baitList;

    public TMP_Dropdown dropdown {get; private set;}
    int dropdownValue;

    private void Awake()
    {
        dropdown = GetComponent<TMP_Dropdown>();
        dropdown.interactable = false;

        targetGraphic = GetComponent<Graphic>();

        ColorBlock cb = dropdown.colors;
        cb.disabledColor = cb.normalColor;
        dropdown.colors = cb;
    }


    private void Start()
    {
        dropdownValue = dropdown.value;
        dropdown.targetGraphic = null;
        NotPressed();
    }

    void Update()
    {
        if (Input.GetKeyDown(fwdKey) && hook.transform.position == hookScript.home)
            Up();
        if (Input.GetKeyDown(backKey) && hook.transform.position == hookScript.home)
            Down();
        else
            NotPressed();
    }


    void NotPressed()
    {
        StartColorTween(dropdown.colors.normalColor, false);
    }

    void Up()
    {
        dropdownValue = dropdownValue + 1;
        if (dropdownValue >= baitList.baits.Length) dropdownValue = 0;
        dropdown.value = dropdownValue;
    }

    void Down()
    {
        dropdownValue = dropdownValue - 1;
        if (dropdownValue < 0) dropdownValue = baitList.baits.Length - 1;
        dropdown.value = dropdownValue;
    }

    void StartColorTween(Color targetColor, bool instant)
    {
        if (targetGraphic == null)
            return;

        targetGraphic.CrossFadeColor(targetColor, instant ? 0f : dropdown.colors.fadeDuration, true, true);
    }

    private void OnApplicationFocus(bool focus)
    {
        NotPressed();
    }
}
