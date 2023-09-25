using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class ItemSpawner : Singleton<ItemSpawner>
{
    [SerializeField]
    private GameObject ItemPrefab;

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
