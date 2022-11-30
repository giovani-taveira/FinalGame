using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChaseController : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;
    public LayerMask whatIsGround, whatIsPlayer;
    private float remainingDistance = 0;

    //Patrulha:
    public Vector3 walkPoint;
    public Vector3 soundWalkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //Estados
    public float sightRange;
    public bool playerInSightRange;
    public bool soundTriggered;

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        soundTriggered = false;
    }

    private void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);

        if (!playerInSightRange && !soundTriggered)
            Patrolling();
        else if (playerInSightRange)
            ChasePlayer();
        else if (soundTriggered || player.GetComponent<PlayerController>().isRunning)
            ChaseSoundPoint();
    }

    public void Patrolling()
    {
        if (!walkPointSet)
            SearchWalkPoint();

        agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //Ponto alcançado:
        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }

    private void SearchWalkPoint()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;
    }

    public void ChasePlayer()
    {
        agent.SetDestination(player.position);
    }

    public void ChaseSoundPoint()
    {
        agent.SetDestination(soundWalkPoint);

        remainingDistance = agent.remainingDistance;
        var distance = Vector3.Distance(this.transform.position, soundWalkPoint);
        if (distance != Mathf.Infinity && distance < 1)
        {
            soundTriggered = false;
            SearchWalkPoint();
        }

    }
}
