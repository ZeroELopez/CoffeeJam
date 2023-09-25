using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class PlayerSpawnPoint : Singleton<PlayerSpawnPoint>
{
    [SerializeField] private PlayerEntity entityToSpawn;

    public void Start()
    {
        SetInstance(this);
        if (Instance == this)
        {
            Instantiate(entityToSpawn, transform);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
