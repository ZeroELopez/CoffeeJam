using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEntity : Entity
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            var attack = collision.collider.GetComponent<Attack>();
            if (attack != null)
            {
                CurrentHealth -= attack.Damage;
                Debug.Log("Damage Enemy");
            }
        }
    }

    public override void OnDeath()
    {
        Destroy(gameObject);
    }

    protected override void Initialize()
    {
    }
}
