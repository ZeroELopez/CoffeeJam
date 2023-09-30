using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAI2 : MonoBehaviour
{
    public GameObject player;
    public float speed;

    protected float distance;
    public float range;

    [SerializeField]
    protected Transform[] patrolRoute;
    protected int patrolIndex;

    [SerializeField]
    protected float patrolTolerance = 0.01f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindFirstObjectByType<PlayerEntity>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            distance = Vector2.Distance(transform.position, player.transform.position);

            if (distance < range)
            {
                transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
                //transform.rotation = Quaternion.Euler(Vector3.forward * angle);
            }
            else
            {
                if (patrolRoute.Length > 0)
                {
                    transform.position = Vector2.MoveTowards(this.transform.position, patrolRoute[patrolIndex].position, speed * Time.deltaTime);
                    if (Vector2.Distance(patrolRoute[patrolIndex].position, transform.position) <= patrolTolerance)
                    {
                        patrolIndex = (patrolIndex + 1) % patrolRoute.Length;
                    }
                }
            }
        }
        else
        {
            player = GameObject.FindFirstObjectByType<PlayerEntity>().gameObject;
        }
    }

    public void SetPatrolRoute(Transform[] route)
    {
        patrolRoute = route;
    }
}
