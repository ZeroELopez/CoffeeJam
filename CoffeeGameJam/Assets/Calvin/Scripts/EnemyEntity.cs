using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEntity : Entity
{
    [SerializeField]
    private int collisionDamage;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            var attack = other.GetComponent<Attack>();

            if (attack != null)
            {
                CurrentHealth -= attack.Damage;
                Debug.Log("Damage Enemy");
            }

            var player = other.GetComponent<PlayerEntity>();
            if (player != null && !player.IsInvincible)
            {
                player.CurrentHealth -= collisionDamage;
                player.StartCoroutine(player.Invincibility());
            }
        }
    }

    public override void OnDeath()
    {
        Destroy(gameObject);
        Spawner.Instance.SpawnItem(gameObject.transform.position);
    }

    protected override void Initialize()
    {
        // leave empty for now.
    }
}
