using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AiScript : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform player;

    public bool playerInSight;

    //patroliing
    public LayerMask whatIsGround, whatIsPlayer;
    bool walkPointSet;
    public float walkPointRange;
    public Vector3 walkPoint;

    //attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;

    //states
    public float susRange, foundRange;
    public bool playerInSusRange, playerInFoundRange;

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        Raycast();
        playerInSusRange = Physics.CheckSphere(transform.position, susRange, whatIsPlayer);
        playerInFoundRange = Physics.CheckSphere(transform.position, foundRange, whatIsPlayer);

        if (!playerInSusRange && !playerInFoundRange) Patroling();
        if (playerInSusRange && !playerInFoundRange && !playerInSight) Patroling();
        if (playerInSusRange && !playerInFoundRange && playerInSight) ChasePlayer();
        if (playerInSusRange && playerInFoundRange) AttackPlayer();
    }

    public void Raycast()
    {
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        Physics.Raycast(transform.position, fwd, out RaycastHit hit);
        string tag = hit.collider.tag;

        if (hit.collider)
            tag = hit.collider.tag;

        if (tag == "Player")
            playerInSight = true;
        else
            playerInSight = false;
    }

    private void Patroling()
    {
        agent.speed = 3.5f;
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

    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
        agent.speed = 1.5f;
    }

    private void AttackPlayer()
    {
        agent.SetDestination(transform.position);

        transform.LookAt(player);

        if (!alreadyAttacked)
        {
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }
}
