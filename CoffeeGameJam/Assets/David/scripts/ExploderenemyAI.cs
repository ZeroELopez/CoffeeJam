using Assets.Scripts.Base.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExploderenemyAI : MonoBehaviour
{
    public GameObject player;
    public float speed;

    private float distance;
    public float range;

    [SerializeField]
    private Transform[] patrolRoute;
    private int patrolIndex;

    [SerializeField]
    private float patrolTolerance = 0.001f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindFirstObjectByType<ExplosionEnemyEtry>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;
        //direction.Normalize();
        //float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;


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

                for (int q = 0; q < range; q++)
                {
                    q++;

                    if (q == range)
                    {
                        EventHub.Instance.PostEvent(new EnemyDisposed());
                        ItemSpawner.Instance.SpawnItem(gameObject.transform.position);

                    }
                }

            }
        }
    }

    public void SetPatrolRoute(Transform[] route)
    {
        patrolRoute = route;
    }



}