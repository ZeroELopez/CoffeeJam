using Assets.Scripts.Base.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(enemyAI2))]
public class EnemyEntity : Entity, ISubscribable<PlayerPowerUpStart>, ISubscribable<PlayerPowerUpEnd>
{

    [SerializeField]
    private int collisionDamage;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "Player")
        {
            var attack = other.collider.GetComponent<Attack>();

            if (attack != null)
            {
                CurrentHealth -= attack.Damage;
                Debug.Log("Damage Enemy");
            }
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        var player = other.collider.GetComponent<PlayerEntity>();
        if (player != null && !player.IsInvincible)
        {
            player.CurrentHealth -= collisionDamage;
            player.StartCoroutine(player.Invincibility());
        }
    }

    public override void OnDeath()
    {
        EventHub.Instance.PostEvent(new EnemyDisposed());
        ItemSpawner.Instance.SpawnItem(gameObject.transform.position);
        Unsubscribe();
        Destroy(gameObject);        
    }

    protected override void Initialize()
    {
        EventHub.Instance.PostEvent(new EnemySpawned());
        Subscribe();
    }

    public void Subscribe()
    {
        EventHub.Instance.Subscribe<PlayerPowerUpStart>(this);
        EventHub.Instance.Subscribe<PlayerPowerUpEnd>(this);
    }

    public void Unsubscribe()
    {
        EventHub.Instance.Unsubscribe<PlayerPowerUpStart>(this);
        EventHub.Instance.Unsubscribe<PlayerPowerUpEnd>(this);
    }

    public void HandleEvent(PlayerPowerUpStart evt)
    {
        GetComponent<enemyAI2>().speed /= 2;
    }

    public void HandleEvent(PlayerPowerUpEnd evt)
    {
        GetComponent<enemyAI2>().speed *= 2;
    }
}
