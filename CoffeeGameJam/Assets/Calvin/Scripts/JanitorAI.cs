using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JanitorAI : enemyAI2
{
    private UsableObject target;

    [SerializeField]
    public float ObjectKillRange;

    private void Start()
    {
        player = GameObject.FindFirstObjectByType<PlayerEntity>().gameObject; ;
    }

    // Update is called once per frame
    void Update()
    {
        if(target != null)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, target.transform.position, speed * Time.deltaTime);
            if(Vector2.Distance(transform.position, target.transform.position) <= ObjectKillRange)
            {
                Destroy(target.gameObject);
                target = null;
            }
        }
        else
        {
            target = GameObject.FindFirstObjectByType<UsableObject>();

            //If not Usable Objects Found, patrol around the level for a player
            if(target == null)
            {
                if(player != null)
                {
                    distance = Vector2.Distance(transform.position, player.transform.position);

                    if (distance < range)
                    {
                        transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
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
            }
            else
            {
                Debug.Log("Found Target Object");
            }
        }
    }
}
