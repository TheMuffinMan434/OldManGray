using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QTEButtonMaker : MonoBehaviour
{
    public GameObject button;

    public ButtonLocal buttonLocal;

    public ProgressBar progreScript;
    public Hook hookScript;

    float time;

    public float spawnHeight;
    public float spawnWidth;

    public bool firstButton;
    private void Start()
    {
        buttonLocal.locations.Clear();
    }

    private void Update()
    {
        if (hookScript.engaged && !hookScript.goingUp && progreScript.points != 100)
        {
            if (firstButton) FirstButton();
            else AddButton();
        }
    }

    public void AddButton()
    {
        time += Time.deltaTime;
        Vector3 buttonPos = GetPosition();
        /*while (!CheckLocationMag(buttonPos))
            buttonPos = GetPosition();*/
        if(time >= GetTime())
        {
            GameObject newButton = Instantiate(button, buttonPos, Quaternion.Euler(0, 0, 0), gameObject.transform);
            buttonLocal.locations.Add(buttonPos);
            time = 0;
        }
    }

    public void FirstButton()
    {
        Vector3 buttonPos = GetPosition();
        GameObject newButton = Instantiate(button, buttonPos, Quaternion.Euler(0, 0, 0), gameObject.transform);
        buttonLocal.locations.Add(buttonPos);
        time = 0;
        firstButton = false;
    }

    public Vector3 GetPosition()
    {
        Vector3 position;
        float xPos = Random.Range(170, spawnWidth);
        float yPos = Random.Range(200, spawnHeight);

        position = new Vector3(xPos, yPos, 0);
        return position;
    }

    public float GetTime()
    {
        float time;
        time = Random.Range(2, 4);
        return time;
    }

    public bool CheckLocationMag(Vector3 positionInQ)
    {
        Vector3 theMag;
        foreach(Vector3 existing in buttonLocal.locations)
        {
            theMag = positionInQ - existing;
            if (theMag.magnitude <= 500)
                return false;
        }
        return true;
    }
}
