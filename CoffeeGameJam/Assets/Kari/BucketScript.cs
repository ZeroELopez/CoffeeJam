using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BucketScript : MonoBehaviour
{
    public static BucketScript instance;

    [SerializeField] GameObject bucket;
    [SerializeField] int maxObjects = 10;
    int onObject = 0;

    public List<GameObject> usableObjects = new List<GameObject>();

    // Start is called before the first frame update
    void Awake()
    {
        instance = this;

        for (int i = 0; i < bucket.transform.childCount; i++)
            usableObjects.Add(bucket.transform.GetChild(i).gameObject);
    }

    public void SpawnObject(Sprite sprite,Vector3 pos)
    {
        GameObject obj = usableObjects[onObject];

        obj.transform.parent = null;
        obj.transform.position = pos;
        obj.GetComponent<SpriteRenderer>().sprite = sprite;

        onObject++;

    }
}
