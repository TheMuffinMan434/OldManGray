using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class FishSpawner : MonoBehaviour
{
    public GameObject gameArea;
    public GameObject biteArea;
    public GameObject[] fishPrefabs;

    public int fishCount;
    public int fishLimit;
    public int fishPerFrame;

    public float spawnCircleRadius;
    public float deathCircleRadius;
    public float fastestSpeed;
    public float slowestSpeed;
    public GameObject canvas;
    public GameObject fishBeacon;

    void Start()
    {
        InitialPopulation();
    }

    void Update()
    {
        MaintainPopulation();
    }

    void InitialPopulation()
    {
        for(int i=0; i<fishLimit; i++)
        {
            Vector3 position = GetRandomPosition(true);
            Fishes fishScript = AddFish(position);
            fishScript.transform.Rotate(Vector3.forward * Random.Range(0.0f, 360.0f));
        }
    }

    void MaintainPopulation()
    {
        if(fishCount < fishLimit)
        {
            for(int i = 0; i < fishPerFrame; i++)
            {
                Vector3 position = GetRandomPosition(false);
                Fishes newFish = AddFish(position);
                newFish.transform.Rotate(Vector3.forward * Random.Range(-45.0f, 45.0f));
            }
        }
    }

    Vector3 GetRandomPosition(bool withinCamera)
    {
        Vector3 position = Random.insideUnitCircle;
        if(withinCamera == false)
        {
            position = position.normalized;
        }
        position *= spawnCircleRadius;
        position += gameArea.transform.position;

        return position;
    }

    Fishes AddFish(Vector3 position)
    {
        int prefabIndex = Random.Range(0, fishPrefabs.Length);
        GameObject fishPrefab = fishPrefabs[prefabIndex];
        fishCount += 1;
        GameObject newFish = Instantiate(fishPrefab, position, Quaternion.FromToRotation(Vector3.up, gameArea.transform.position - position), gameObject.transform);

        Fishes fishScript = newFish.GetComponent<Fishes>();
        fishScript.fishSpawner = this;
        fishScript.gameArea = gameArea;
        fishScript.speed = Random.Range(slowestSpeed, fastestSpeed);
        fishScript.speed *= fishScript.speedMult;
        fishScript.biteArea = biteArea;
        fishScript.fishBeacon = fishBeacon;
        /*fishScript.raycaster = canvas.GetComponent<GraphicRaycaster>();
        fishScript.eventSystem = GetComponent<EventSystem>();*/

        return fishScript;
    }
}
