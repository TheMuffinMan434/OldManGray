using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Fishes : MonoBehaviour
{
    public FishSpawner fishSpawner;
    public GameObject gameArea;
    public GameObject biteArea;
    private GameObject objectHit;

    private string hitTag;
    public float speed;
    public float speedMult = 1;
    public bool swimPointSet;
    public int swimRange;
    public Vector2 swimPoint;


    /*public GraphicRaycaster raycaster;
    public EventSystem eventSystem;
    PointerEventData pointerEvent;*/

    Quaternion currentRotation;
    Vector3 currentEuler;
    public GameObject fishBeacon;
    bool hitInRange;
    public string hitDirection;
    bool bite = false;

    void Update()
    {
        Move();
        Raycast();
    }

    void Raycast()
    {
        /*pointerEvent = new PointerEventData(eventSystem);
        pointerEvent.position = transform.localPosition;

        List<RaycastResult> results = new List<RaycastResult>();

        raycaster.Raycast(pointerEvent, results);

        *//*if (results.Count > 0) Debug.Log("hit");*//*
        var raycastResults = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointerEvent, raycastResults);
        if (raycastResults.Count > 0)
        {
            foreach (RaycastResult result in results)
            {
                Debug.Log(result);
                if (result.gameObject.name == "RepelantWave")
                {
                    Debug.Log("this one!!!" + gameObject.name);
                    *//*Bite();*//*
                }

            }

        }*/
        Physics.Raycast(transform.position, Vector2.up, out RaycastHit hitUp);
        Physics.Raycast(transform.position, Vector2.down, out RaycastHit hitDown);
        Physics.Raycast(transform.position, Vector2.right, out RaycastHit hitRight);
        Physics.Raycast(transform.position, Vector2.left, out RaycastHit hitLeft);

        if (!bite)
        {
            if (hitInRange = hitUp.distance <= 250)
            {
                hitDirection = "Up";
                if (hitUp.collider && hitInRange)
                {
                    Debug.Log("hit up " + gameObject.name);
                    if (hitUp.collider.tag == "RepelantWave")
                        Bite(hitDirection);
                }
            }
            if (hitInRange = hitDown.distance <= 250)
            {
                hitDirection = "Down";
                if (hitDown.collider && hitInRange)
                {
                    Debug.Log("hit down " + gameObject.name);
                    if (hitDown.collider.tag == "RepelantWave")
                        Bite(hitDirection);
                }
            }
            if (hitInRange = hitRight.distance <= 250)
            {
                hitDirection = "Right";
                if (hitRight.collider && hitInRange)
                {
                    Debug.Log("hit right "  + gameObject.name);
                    if (hitRight.collider.tag == "RepelantWave")
                        Bite(hitDirection);
                }
            }
            if (hitInRange = hitLeft.distance <= 250)
            {
                hitDirection = "Left";
                if (hitLeft.collider && hitInRange)
                {
                    Debug.Log("hit left " + gameObject.name);
                    if (hitLeft.collider.tag == "RepelantWave")
                        Bite(hitDirection);
                }
            }
        }

    }

    void Move()
    {
        /*if (!swimPointSet) SetSwimPoint();*/

        transform.position += transform.up * (Time.deltaTime * speed);

        /*transform.position += transform.right * (Time.deltaTime * speed);*/

        float distance = Vector3.Distance(transform.position, gameArea.transform.position);
        if(distance > fishSpawner.deathCircleRadius)
            RemoveFish();
    }

    /*void SetSwimPoint()
    {
        float swimX = Random.Range(-swimRange, swimRange);
        float swimY = Random.Range(-swimRange, swimRange);
        swimPoint = new Vector2(transform.position.x + swimX, transform.position.y + swimY);
        swimPointSet = true;
    }*/

    void RemoveFish()
    {
        Destroy(gameObject);
        fishSpawner.fishCount -= 1;
    }

    void Bite(string direction)
    {
        currentEuler += new Vector3(0f, 0f, 1f) * Time.deltaTime;
        currentRotation.eulerAngles = currentEuler;
        transform.rotation = currentRotation;
        if(transform.position == fishBeacon.transform.position)
        {
            //its fishing time
            Debug.Log("its fishing time");
        }
    }
}
