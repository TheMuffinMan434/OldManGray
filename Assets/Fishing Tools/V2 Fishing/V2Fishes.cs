using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class V2Fishes : MonoBehaviour
{
    public V2Spawner fishSpawner;
    public GameObject gameArea;
    public Hook hookScript;
    public GameObject hook;
    public QTEButtonMaker buttonMaker;
    public FishingScore scoreTracker;
    
    public float speed;
    public bool swimPointSet;
    public int swimRange;
    public Vector2 swimPoint;
    public Vector3 distanceToHook;

    public bool fishEngaged = false;

    //set individually
    public Baits weakness;
    public float speedMult;
    public int pointsWorth;

    void Update()
    {
        if(!fishEngaged) Move();
        CatchCheck();
        NotInterested();
    }


    void Move()
    {
        transform.position += transform.up * (Time.deltaTime * speed * speedMult);

        if (transform.position.x > fishSpawner.spawnWidth || transform.position.x < -60)
            RemoveFish(false);

        if(!hookScript.atHome)
        {
            distanceToHook = transform.position - hook.transform.position;
            if(distanceToHook.magnitude < 125 && !hookScript.engaged && !hookScript.moving && hookScript.baitSelected == weakness.baitName)
            {
                ImHooked();
            }
        }
    }

    public void CatchCheck()
    {
        if (hookScript.goingUp && fishEngaged)
            transform.position = hook.transform.position;
        Vector3 distanceToHome = transform.position - hookScript.home;
        if (distanceToHome.magnitude < 1.5)
            RemoveFish(true);
    }

    void ImHooked()
    {
        hookScript.engaged = true;
        fishEngaged = true;
        buttonMaker.firstButton = true;
        transform.position = hook.transform.position;
    }

    public void NotInterested()
    {
        if (fishEngaged && hookScript.fishingFail)
        {
            fishEngaged = false;
            hookScript.engaged = false;
        }
    }

    void RemoveFish(bool caught)
    {
        Destroy(gameObject);
        fishSpawner.fishCount -= 1;
        if (caught)
        {
            scoreTracker.fishingScore += pointsWorth;
            hookScript.engaged = false;
        }
    }
}
