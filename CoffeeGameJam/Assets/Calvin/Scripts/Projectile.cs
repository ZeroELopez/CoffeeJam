using Assets.Scripts.Base.Events;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent (typeof (CircleCollider2D))]
public class Projectile : MonoBehaviour
{
    [SerializeField]
    //How much time in seconds 
    public float TravelTime;

    [SerializeField]
    public int Damage = 1;

    [SerializeField] 
    public float Speed;

    [SerializeField]
    public Vector3 Direction;

    private void Start()
    {
        StartCoroutine(Travel());
    }

    void Update()
    {
        transform.position += Speed * Direction * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var player = collision.GetComponent<PlayerEntity>();
        if (player != null && !player.IsInvincible)
        {
            EventHub.Instance.PostEvent(new PlayerIsHit());
            player.CurrentHealth -= Damage;
            player.StartCoroutine(player.Invincibility());
            Destroy(gameObject);
        }
    }

    private IEnumerator Travel()
    {
        yield return new WaitForSeconds (TravelTime);
        Destroy(gameObject);
    }
}
