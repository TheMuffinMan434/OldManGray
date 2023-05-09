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
    public bool engaged;
    public bool goingUp;
    public TMP_Text count;
    public GameObject progressBar;
    public ProgressBarPoint progressScriptable;

    public int fishCounter;

    public void Start()
    {
        engaged = false;
        moving = false;
        atHome = true;
        goingUp = false;
        fishingFail = false;
        fishCounter = 0;

        home = transform.position; 
        
    }

    private void Update()
    {
        count.text = fishCounter.ToString();
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

        if (transform.position == home) NotFishing();
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
}
