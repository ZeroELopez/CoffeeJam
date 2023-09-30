using Assets.Scripts.Base.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Collider2D))]
public class LevelExit : MonoBehaviour, ISubscribable<EnemySpawned>, ISubscribable<EnemyDisposed>
{
    private int unlockThreshold;
    public string NextScene;

    public void Awake()
    {
        Subscribe();
    }

    public void OnDestroy()
    {
        if (EventHub.Instance != null)
        {
            Unsubscribe();
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.GetComponent<PlayerEntity>() != null)
        {
            if (unlockThreshold <= 0)
            {
                EventHub.Instance.PostEvent(new HideHealthbar());
                SceneLoaderModule.LoadLevel(NextScene);
            }
            else
            {
                Debug.Log("Can't exit yet!");
            }
        }
    }

    public void Subscribe()
    {
        EventHub.Instance.Subscribe<EnemySpawned>(this);
        EventHub.Instance.Subscribe<EnemyDisposed>(this);
    }

    public void Unsubscribe()
    {
        EventHub.Instance.Unsubscribe<EnemySpawned>(this);
        EventHub.Instance.Unsubscribe<EnemyDisposed>(this);
    }

    public void HandleEvent(EnemySpawned evt)
    {
        unlockThreshold++;
    }

    public void HandleEvent(EnemyDisposed evt)
    {
        Debug.Log("Enemy Killed");
        unlockThreshold--;
    }
}
