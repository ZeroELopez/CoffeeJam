using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Collectible : MonoBehaviour
{
    [SerializeField]
    private int healthValue;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerEntity>().CurrentHealth += healthValue;
            Destroy(gameObject);
        }
    }
}
