using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Hook : MonoBehaviour
{
    public Vector2 PointerPosition;
    public GameObject hookContainer;
    public bool atHome;
    public bool moving;
    public bool fishingFail;
    public Vector3 home;
    private Vector3 magToHome;
    public bool engaged;
    public bool goingUp;
    public TMP_Text score;
    public GameObject progressBar;
    public ProgressBarPoint progressScriptable;
    public BaitImage baitImgScript;
    public string baitSelected;
    public int fishCountMultiplier;

    public FishingScore fishingScore;

    public void Start()
    {
        engaged = false;
        moving = false;
        atHome = true;
        goingUp = false;
        fishingFail = false;

        home = transform.position; 
        
    }

    private void Update()
    {
        baitSelected = baitImgScript.baitName;
        score.text = fishingScore.fishingScore.ToString();
        PointerPosition = GetPointerInput();

        if (Input.GetKeyDown(KeyCode.Mouse0) && atHome) {
            goingUp = false;
            StartCoroutine(HookDecends(PointerPosition));
        }
        if(Input.GetKeyDown(KeyCode.Mouse0) && !atHome && !engaged)
        {
            goingUp = true;
            StartCoroutine(HookDecends(home));
        }
        if(progressScriptable.points >= 100)
        {
            goingUp = true;
            StartCoroutine(HookDecends(home));
            progressScriptable.points = 0;
        }
        if(progressScriptable.points < 0)
        {
            goingUp = true;
            StartCoroutine(HookDecends(home));
            progressScriptable.points = 0;
            fishingFail = true;
        }


        magToHome = transform.position - home;
        if (magToHome.magnitude < .5f) NotFishing();
        else atHome = false;

        if (engaged) progressBar.SetActive(true);
        else progressBar.SetActive(false);
    }

    public void Hooking(Vector2 target)
    {
        if(transform.position.y > target.y)
        {
            transform.position -= transform.up;
        }
        else if (transform.position.y < target.y)
        {
            transform.position += transform.up;
        }
    }

    private IEnumerator HookDecends(Vector2 target)
    {
        while (hookContainer.transform.position.y > target.y){
            moving = true;
            yield return new WaitForSeconds (.001f);
            Hooking(target);
        }
        while(hookContainer.transform.position.y < target.y){
            moving = true;
            yield return new WaitForSeconds(.001f);
            Hooking(target);
        }
        moving = false;
    }

    public void NotFishing()
    {
        goingUp = false;
        atHome = true;
        fishingFail = false;
        if (InRange((-PointerPosition + (Vector2)transform.position).normalized)) transform.up = (-PointerPosition + (Vector2)transform.position).normalized;
    }

    public Vector2 GetPointerInput()
    {
        Vector2 mousePos = Input.mousePosition;
        return mousePos;
    }

    public bool InRange(Vector2 vector)
    {
        float value = vector.y;
        double minRange = .5;
        double maxRange = 1;
        return value >= minRange && value <= maxRange;
    }

    public void ContinuousFishing()
    {
        
    }
}
