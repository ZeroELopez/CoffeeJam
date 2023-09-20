using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyAI : MonoBehaviour
{
        public NavMeshAgent agent;

        public Transform Player;

        public LayerMask whatIsGround, whatIsPlayer;

    //Looking for Player
    public Vector3 walkPoint;
    bool walkSet;
    public bool walkRange;
    public float walkPointRange;

    //Attacking
    public float timeforAttack;
    bool attackedAlready;

    //States
    public float sightRange, attackRange;
    public bool playerInSigntRange, playerInAttackRange;

    private void Awake()
    {
        Player = GameObject.Find("Pla").transform;
        agent = GetComponent<NavMeshAgent>();

    }

    private void Update()
    {
        //Check in range and attack range
        playerInSigntRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);

        if (!playerInSigntRange && !playerInAttackRange) looking();
        if (playerInSigntRange && !playerInAttackRange) chasing();
        if (playerInSigntRange &&playerInAttackRange) Attacking();


    }

    private void looking()
    {
        if (!walkRange) search();
        if (walkRange)
            agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        if (distanceToWalkPoint.magnitude < 1f)
            walkRange = false;

    }


    private void search()
    {
        float ramdomz = Random.Range(-walkPointRange, walkPointRange);
        float ramdony = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.x);

    }

    private void chasing()
    {
        agent.SetDestination(Player.position);


    }

    private void Attacking()
    {
        agent.SetDestination(transform.position);

        transform.LookAt(Player);

        if (!attackedAlready)
        {
            attackedAlready = true;
            Invoke(nameof(resetAttack), timeforAttack);
        }
    }
    private void resetAttack()
    {

     attackedAlready = false;
        
    }

}
