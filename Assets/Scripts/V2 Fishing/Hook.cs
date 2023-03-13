using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Hook : MonoBehaviour
{
    public Vector2 PointerPosition;
    public GameObject hookContainer;
    public bool leftClick;
    public bool moving;
    public Vector3 home;
    public bool engaged;
    public bool noticeMeSenpai;
    public bool goingUp;
    public TMP_Text count;

    public int fishCounter;

    public void Start()
    {
        noticeMeSenpai = false;
        engaged = false;
        moving = false;
        leftClick = false;
        goingUp = false;
        fishCounter = 0;

        home = transform.position; 
        
    }

    private void Update()
    {
        count.text = fishCounter.ToString();
        PointerPosition = GetPointerInput();

        if (Input.GetKeyDown(KeyCode.Mouse0) && !leftClick) {
            goingUp = false;
            StartCoroutine(HookDecends(PointerPosition));
            StartCoroutine(IFishing());
        }
        if(Input.GetKeyDown(KeyCode.Mouse0) && leftClick)
        {
            goingUp = true;
            StartCoroutine(HookDecends(home));
            StopCoroutine(IFishing());
        }

        if (transform.position == home)
            NotFishing();
        else leftClick = true;
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
        leftClick = false;
        if (InRange((-PointerPosition + (Vector2)transform.position).normalized)) transform.up = (-PointerPosition + (Vector2)transform.position).normalized;
    }

    public IEnumerator IFishing()
    {
        while (!moving)
        {
            yield return new WaitForSeconds(2f);
            Fishing();
        }
    }
    private void Fishing()
    {
        noticeMeSenpai = true;
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
