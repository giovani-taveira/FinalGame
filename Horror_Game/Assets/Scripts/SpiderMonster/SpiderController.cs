using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderController : MonoBehaviour
{
    [SerializeField] Transform playerTransform;
    [SerializeField] float velocityToIncrease;
    UnityEngine.AI.NavMeshAgent agent;

    float timeToStart = 1;
    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    void Update()
    {
        timeToStart += timeToStart * Time.deltaTime * 0.1f;
        Debug.Log("Time: " + timeToStart);

        if (timeToStart >= 1f)
        {
            agent.SetDestination(playerTransform.position);

            if (agent.speed < 12)
                agent.speed += velocityToIncrease * Time.deltaTime;
        }
    }
}
