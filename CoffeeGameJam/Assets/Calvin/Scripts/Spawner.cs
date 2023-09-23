using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class Spawner : Singleton<Spawner>
{
    [SerializeField]
    private GameObject EnemyPrefab;

    [SerializeField]
    private GameObject ItemPrefab;

    public Transform[] EnemySpawnLocations;

    public void Start()
    {
        SetInstance(this);
        DontDestroyOnLoad(this);
    }

    public void SpawnItem(Vector3 location)
    {
        Instantiate(ItemPrefab, location, Quaternion.identity);
    }
}
