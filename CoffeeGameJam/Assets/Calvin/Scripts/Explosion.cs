using Assets.Scripts.Base.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class Explosion : MonoBehaviour
{
    private CircleCollider2D explosionCollider;

    [SerializeField]
    public float ExplosionRange;

    [SerializeField]
    public float ExplosionTime;

    [SerializeField]
    public int ExplosionDamage;

    private void Start()
    {
        explosionCollider = GetComponent<CircleCollider2D>();

        StartCoroutine(Explode());
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        var player = other.GetComponent<PlayerEntity>();
        if (player != null && !player.IsInvincible)
        {
            EventHub.Instance.PostEvent(new PlayerIsHit());
            player.CurrentHealth -= ExplosionDamage;
            player.StartCoroutine(player.Invincibility());
        }

        var enemy = other.GetComponent<EnemyEntity>();
        if(enemy != null)
        {
            EventHub.Instance.PostEvent(new EnemyIsHit());
            enemy.CurrentHealth -= ExplosionDamage;
        }
    }

    private IEnumerator Explode()
    {
        yield return new WaitForSeconds(ExplosionTime);
        Destroy(gameObject);
    }
}
