using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class V2Fishes : MonoBehaviour
{
    public V2Spawner fishSpawner;
    public GameObject gameArea;
    public Hook hookScript;
    public GameObject hook;

    public float speed;
    public float speedMult = 1;
    public bool swimPointSet;
    public int swimRange;
    public Vector2 swimPoint;
    public Vector3 distanceToHook;

    public bool fishEngaged = false;

    void Update()
    {
        if(!fishEngaged) Move();
        CatchCheck();
    }


    void Move()
    {
        transform.position += transform.up * (Time.deltaTime * speed);

        if (transform.position.x > fishSpawner.spawnWidth || transform.position.x < -60)
            RemoveFish(false);

        if(hookScript.leftClick)
        {
            distanceToHook = transform.position - hook.transform.position;
            if(distanceToHook.magnitude < 125 && !hookScript.engaged && !hookScript.moving)
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
        transform.position = hook.transform.position;
    }

    void RemoveFish(bool caught)
    {
        Destroy(gameObject);
        fishSpawner.fishCount -= 1;
        if (caught)
        {
            hookScript.fishCounter += 1;
            hookScript.engaged = false;
        }
    }
}
