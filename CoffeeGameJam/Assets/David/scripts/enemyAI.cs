using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        public NavMeshAgent agent;

        public Transform Player;

        public LayerMask whatIsGround, whatIsPlayer;

    //Looking for Player
    public Vector walking;
    bool walkSet;
    public float walkRange;

    //Attacking
    public float timeforAttack;
    bool attackedAlready;

    //States
    public float sightRange, attackRange;
    public bool playerInSigntRange, playerInAttackRange;

    private void Awake()
    {
        Player = GameObject.Find('Pla').transform;
        agemt = GetComponent<NavMeshAgent>;

    }

    private void Update()
    {
        //Check in range and attack range
        playerInSigntRange = Physics.CheckShpere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckShpere(transform.position, sightRange, whatIsPlayer);

        if (!playerInSigntRange && !playerInAttackRange) looking();
        if (playerInSigntRange && !playerInAttackRange) chasing();
        if (playerInSigntRange &&playerInAttackRange) Attacking();


    }

    private void looking()
    {
        if (!walkRange) search()
        if (walkRange)
            agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkRange;

        if (distanceToWalkPoint.magnitude < 1f)
            walkRange = false;

    }


    private void search()
    {
        float ramdomz = Random.Range(-walkPointRange, walkPointRange);
        float ramdony = Random.Range(-walkPointRange, walkPointRange);

        walkRange = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.x)

    }

    private void chasing()
    {
        agent.SetDestination(Player.position);


    }

    priviate void Attacking()
    {
        agent.SetDestination(transform.positon);

        transform.LookAt(player);

        if (!attackedAlready)
        {
            attackedAlready = true;
            invoke(nameof(resetAttack), timeforAttack);
        }
    }
    private void resetAttack()
    {

    }
     attackedAlready = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
