using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class V2Spawner : MonoBehaviour
{
    public GameObject gameArea;
    public GameObject[] fishPrefabs;

    public int fishCount;
    public int fishLimit;
    public int fishPerFrame;

    public Hook hookScript;
    public GameObject hook;

    public float spawnWidth;
    public float spawnHeight;
    public float fastestSpeed;
    public float slowestSpeed;
    public GameObject canvas;

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
        for (int i = 0; i < fishLimit; i++)
        {
            Vector3 position = GetRandomPosition(3);
            V2Fishes fishScript = AddFish(position);
            if (fishScript.transform.position.x < 960)
                fishScript.transform.Rotate(new Vector3(0, 180, 90));
            else
                fishScript.transform.Rotate(new Vector3(0, 0, 90));
        }
    }

    void MaintainPopulation()
    {
        if (fishCount < fishLimit)
        {
            for (int i = 0; i < fishPerFrame; i++)
            {
                Vector2 position = GetRandomPosition(Random.Range(1, 3));
                V2Fishes newFish = AddFish(position);
                if (newFish.transform.position.x < 960)
                    newFish.transform.Rotate(new Vector3(0, 180, 90));
                else
                    newFish.transform.Rotate(new Vector3(0, 0, 90));
            }
        }
    }

    Vector3 GetRandomPosition(int whichEnd)
    {
        Vector3 position;
        float xPos = Random.Range(-40, spawnWidth);
        float yPos = Random.Range(10, spawnHeight);

        if (whichEnd == 1)
            position = new Vector3(-60f, yPos, 0);
        else if (whichEnd == 2)
            position = new Vector3(spawnWidth, yPos, 0);
        else
            position = new Vector3(xPos, yPos, 0);
        return position;
    }

    V2Fishes AddFish(Vector3 position)
    {
        int prefabIndex = Random.Range(0, fishPrefabs.Length);
        GameObject fishPrefab = fishPrefabs[prefabIndex];
        fishCount += 1;
        GameObject newFish = Instantiate(fishPrefab, position, Quaternion.Euler(0, 0, 0), gameObject.transform);

        V2Fishes fishScript = newFish.GetComponent<V2Fishes>();
        fishScript.fishSpawner = this;
        fishScript.gameArea = gameArea;
        fishScript.speed = Random.Range(slowestSpeed, fastestSpeed);
        fishScript.speed *= fishScript.speedMult;
        fishScript.hook = hook;
        fishScript.hookScript = hookScript;

        return fishScript;
    }
}
