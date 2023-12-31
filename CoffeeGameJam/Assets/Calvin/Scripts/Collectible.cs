using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Collectible : MonoBehaviour
{
    [SerializeField]
    private int healthValue;

    [SerializeField] private int powerupValue;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            var player = collision.gameObject.GetComponent<PlayerEntity>();
            if (player != null)
            { 
                player.CurrentHealth += healthValue;
                player.PowerGauge += powerupValue;
            }
            Destroy(gameObject);
        }
    }
}
