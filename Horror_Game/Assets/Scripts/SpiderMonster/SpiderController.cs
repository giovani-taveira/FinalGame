using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderController : MonoBehaviour
{
    [SerializeField] Transform playerTransform;
    [SerializeField] float velocityToIncrease;
    UnityEngine.AI.NavMeshAgent agent;
    public bool canReachPlayer;

    float timeToStart = 1;
    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        canReachPlayer = false;
    }

    void Update()
    {
        if (canReachPlayer)
        {
            timeToStart += timeToStart * Time.deltaTime * 0.1f;

            if (timeToStart >= 50f)
            {
                agent.SetDestination(playerTransform.position);

                if (agent.speed < 12)
                    agent.speed += velocityToIncrease * Time.deltaTime;
            }
        }
    }
}
