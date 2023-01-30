using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldofView : MonoBehaviour
{
    public float radius;
    [Range(0, 360)]
    public float angle;

    public GameObject playerRef;

    public LayerMask targetMask;
    public LayerMask obstructionMask;
    public LayerMask wallMask;

    public bool canSeePlayer;
    public bool lookForPlayer;
    public CharacterControl player;

    public DetectionBarController detection;

    public float waitSec = 0.1f;
    private void Start()
    {
        playerRef = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(FOVRoutine());
    }

    private IEnumerator FOVRoutine()
    {
        WaitForSeconds wait = new WaitForSeconds(waitSec);

        while (true)
        {
            yield return wait;
            FieldofViewCheck();
        }
    }

    private void FieldofViewCheck()
    {
        waitSec = 0.1f;
        Collider[] rangeChecks = Physics.OverlapSphere(transform.position, radius, targetMask);

        if (rangeChecks.Length != 0)
        {
            Transform target = rangeChecks[0].transform;
            Vector3 directionToTarget = (target.position - transform.position).normalized;

            if (Vector3.Angle(transform.forward, directionToTarget) < angle / 2)
            {
                float distanceToTarget = Vector3.Distance(transform.position, target.position);
                //Obstruction
                if (Physics.Raycast(transform.position, directionToTarget, distanceToTarget, obstructionMask))
                {
                    if (player.isCrouched)
                        canSeePlayer = false;
                    else
                        canSeePlayer = true;
                }
                else
                {
                    //no wall
                    if (Physics.Raycast(transform.position, directionToTarget, distanceToTarget, wallMask))
                        canSeePlayer = false;
                    //wall
                    else
                        canSeePlayer = true;
                }

            }
            else
                canSeePlayer = false;
        }
        else if (canSeePlayer)
            canSeePlayer = false;

        LookForPlayer(rangeChecks.Length);
        

        Debug.Log("see player: " + canSeePlayer);
    }

    public void LookForPlayer(int inRange)
    {
        if (inRange != 0)
            lookForPlayer = true;
        else
            lookForPlayer = false;
    }


    public void WalkAway()
    {
        Debug.Log("going");
        waitSec = 4f;
        canSeePlayer = false;
        lookForPlayer = false;
    }



}
