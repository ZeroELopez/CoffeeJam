using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class UsableObjectBucket : MonoBehaviour
{
    public static UsableObjectBucket instance;

    public int minimumUsableObjects = 1;

    public List<UsableObject> usableObjects = new List<UsableObject>();
    public Queue<UsableObject> usedObjects = new Queue<UsableObject>();

    public static Sprite LastUsedSprite;

    // Start is called before the first frame update
    void Awake()
    {
        instance = this;

        UsableObject[] allObjects = GameObject.FindObjectsOfType<UsableObject>();

        for (int i = 0; i < allObjects.Length; i++)
            usableObjects.Add(allObjects[i]);
    }

    public static bool ObjectNearby(Vector3 position, float reach, out UsableObject obj)
    {
        obj = null;

        for(int i = 0; i < instance.usableObjects.Count;i++)
            if (Vector3.Distance(instance.usableObjects[i].transform.position,position) <= reach)
            {
                instance.UseObject(instance.usableObjects[i]);

                //instance.onUsed?.Invoke(instance.usableObjects[i].spriteRenderer.sprite);
                onUsedAction?.Invoke(LastUsedSprite);//Because the top one didn't work

                //Debug.Log("use object");
                return true;
            }

        return false;
    }
    int count;
    public void CheckUsedCount()
    {
        if(usableObjects.Count < minimumUsableObjects)
        {
            UsableObject obj = usedObjects.Dequeue();
            obj.Respawn();
            usableObjects.Add(obj);
        }
    }

    public void UseObject(UsableObject obj)
    {
        obj.Use();

        instance.usedObjects.Enqueue(obj);
        instance.usableObjects.Remove(obj);

        instance.CheckUsedCount();
        LastUsedSprite = obj.spriteRenderer.sprite;

    }

    public UnityEvent onRespawn;

    public UnityEvent<Sprite> onUsed;
    public static event Action<Sprite> onUsedAction;

    public UnityEvent onStart;


}
