using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

public class EntityEventTracker : MonoBehaviour
{
    public static PlayerEntity player;

    [SerializeField] Entity script;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindObjectOfType<PlayerEntity>();

        script = GetComponentInParent<Entity>();

        if (script.GetType() == typeof(PlayerEntity))
            prevState = new PlayerState((PlayerEntity)script);

        if (script.GetType() == typeof(EnemyEntity))
            prevState = new EnemyState((EnemyEntity)script);
    }

    public UnityEvent<EntityState> onHit;
    public UnityEvent<EntityState> onAttack;
    public UnityEvent<EntityState> onAttackEnd;


    EntityState prevState;
    // Update is called once per frame
    void Update()
    {
        List<string> logs = new List<string>();

        if (prevState.ChangedState(script, out logs))
        {
            foreach (string eventName in logs)
            {
                var backingField = this.GetType().GetField(eventName);
                var delegateInstance = (UnityEvent<EntityState>)backingField.GetValue(this);
                delegateInstance?.Invoke(prevState);
            }

            if (script.GetType() == typeof(PlayerEntity))
                prevState = new PlayerState((PlayerEntity)script);

            if (script.GetType() == typeof(EnemyEntity))
                prevState = new EnemyState((EnemyEntity)script);
        }
    }

}


public interface EntityState
{
    int CurrentHealth { get; set; }

    //void CopyState(Entity state);
    bool ChangedState(Entity e, out List<string> logs);
}

public struct EnemyState : EntityState
{
    public int CurrentHealth { get; set; }

    public EnemyState(EnemyEntity state)
    {
        CurrentHealth = state.CurrentHealth;
    }

    public bool ChangedState(Entity e, out List<string> logs)
    {
        EnemyEntity b = (EnemyEntity)e;
        logs = new List<string>();

        if (CurrentHealth != b.CurrentHealth)
        {
            Debug.Log("Health Changed");
            BucketScript.instance.SpawnObject(UsableObjectBucket.LastUsedSprite, e.transform.position);
            logs.Add("onHit");
        }

        return logs.Count > 0;
    }
}

public struct PlayerState : EntityState
{
    public int CurrentHealth { get; set; }
    bool isAttacking;

    public float attackFrames; 


    public PlayerState(PlayerEntity state)
    {
        CurrentHealth = state.CurrentHealth;
        isAttacking = state.isAttacking;
        attackFrames = state.attackFrames; 
    }

    public bool ChangedState(Entity e, out List<string> logs)
    {
        PlayerEntity b = (PlayerEntity)e;

        logs = new List<string>();

        if (CurrentHealth > b.CurrentHealth)
            logs.Add("onHit");

        if (isAttacking != b.isAttacking)
        {
            UsableObjectBucket.ObjectNearby(e.transform.position, 2, out UsableObject obj);

            if (b.isAttacking)
                logs.Add("onAttack");
            else
                logs.Add("onAttackEnd");
        }


        return logs.Count > 0;
    }
}
