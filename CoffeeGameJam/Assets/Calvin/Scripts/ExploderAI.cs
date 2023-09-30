using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyEntity))]
public class ExploderAI : enemyAI2
{
    [SerializeField]
    public Explosion Explosion;

    private EnemyEntity entity;

    private void Start()
    {
        player = GameObject.FindFirstObjectByType<PlayerEntity>().gameObject;
        entity = GetComponent<EnemyEntity>();
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);

        Debug.Log("Distance: " + distance + " Explosion Range: " + Explosion.ExplosionRange);

        if(distance < Explosion.ExplosionRange)
        {
            Instantiate(Explosion, transform.position, transform.rotation);
            entity.OnDeath();
        }
        else if (distance < range)
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
}
