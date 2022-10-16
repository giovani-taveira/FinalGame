using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderController : MonoBehaviour
{
    [SerializeField] Transform playerTransform;
    [SerializeField] float velocityToIncrease;
    UnityEngine.AI.NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    void Update()
    {
        agent.SetDestination(playerTransform.position);

        if (agent.speed < 12)
            agent.speed += velocityToIncrease * Time.deltaTime;
    }
}
