using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class EnemySpawnPoint : MonoBehaviour
{
    [SerializeField] private EnemyEntity entityToSpawn;

    [SerializeField] private Transform[] patrolPoints;
    public void Start()
    {
        entityToSpawn.GetComponent<enemyAI2>().SetPatrolRoute(patrolPoints);
        Instantiate(entityToSpawn, transform);
    }
}
