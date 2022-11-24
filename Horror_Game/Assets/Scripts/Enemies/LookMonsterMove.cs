using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LookMonsterMove : MonoBehaviour
{
  private Transform player;
  private NavMeshAgent agent;
  private Camera mainCamera;
  public float enemyDistance = 0.7f;
  public LayerMask Mask;
  public float velocity = 100.0f;
  Renderer rend { get { return GetComponent<Renderer>(); } set { rend = value; } }
  public Light lanterna;
  private Animator anim;

  public LookMonsterSentence lookMonsterEnablerScript;
  public bool onTheHouse = false;
  void Start()
  {
      player = GameObject.FindWithTag("Player").transform;
      mainCamera = Camera.main;
      agent = GetComponent<NavMeshAgent>();
      agent.acceleration = velocity;
      anim = GetComponent<Animator>();
  }

  void Update()
  {
    if (lookMonsterEnablerScript.firstTimeLookMonster && onTheHouse)
    {
        agent.SetDestination(player.transform.position);
        agent.isStopped = false;

        if (Vector3.Distance(transform.position, player.position) < enemyDistance)
        {
            agent.velocity = Vector3.zero;
            anim.enabled = false;
        }
    }  
  }

  public void StopMovement()
  {
    if(lanterna.intensity != 0)
    {
      agent.velocity = Vector3.zero;
      agent.SetDestination(Vector3.zero);
      agent.isStopped = true;
      anim.enabled = false;
    }
  }
}
