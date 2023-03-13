using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine. UI;

public class AiScript : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform player;
    public Caught caught;

    public bool playerInSight;

    //other scripts
    public FieldofView fov;
    public DetectionBarController detection;
    public Cupboard cupboard;

    //patrolling
    public LayerMask whatIsGround, whatIsPlayer;
    bool walkPointSet;
    public float walkPointRange;
    public Vector3 walkPoint;
    public float patrollingSpeed;

    //attacking
    public float chasingSpeed;

    //GameObjects 
    public GameObject dectContainer;
    public GameObject seen;

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        caught.caught = false;
        dectContainer.SetActive(false);
        seen.SetActive(false);
    }

    private void Update()
    {
        if (fov.canSeePlayer == false) Patroling();
        if (fov.lookForPlayer == false) Patroling();
        if (cupboard.inTheBoard == true) Patroling();
        if (fov.lookForPlayer == true && cupboard.inTheBoard == false) Looking();
        if (detection.found == true && cupboard.inTheBoard == false) ChasePlayer();
        if (cupboard.inTheBoard) TheyInTheCupboard();
    }

    private void Patroling()
    {
        agent.speed = 3.5f;
        agent.isStopped = false;
        detection.NotSus();
        if(detection.detectionLvl == 0) dectContainer.SetActive(false);
        if (!walkPointSet) SearchWalkPoint();
        if (agent.pathStatus == NavMeshPathStatus.PathInvalid || agent.pathStatus == NavMeshPathStatus.PathPartial) SearchWalkPoint();

        if (walkPointSet) agent.SetDestination(walkPoint);
       

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //Walkpoint reached
        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;

    }

    public void SearchWalkPoint()
    {
        //calculate Random point in range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, 1.5f, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround)) walkPointSet = true;
    }

    private void Looking()
    {
        agent.isStopped = true;
        dectContainer.SetActive(true);
        transform.LookAt(player);
    }

    private void ChasePlayer()
    {
        agent.isStopped = false;
        dectContainer.SetActive(false);
        seen.SetActive(true);
        agent.speed = chasingSpeed;
        agent.SetDestination(player.position);

        Vector3 distanceToPlayer = transform.position - player.position;
        if (distanceToPlayer.magnitude < 1.7f)
        {
            caught.caught = true;
        }
        else
            caught.caught = false;
    }

    private void TheyInTheCupboard()
    {
        seen.SetActive(false);
        detection.found = false;
        if(detection.detectionLvl == detection.maxDetection)
            detection.detectionLvl -= 2;
        
    }
}
