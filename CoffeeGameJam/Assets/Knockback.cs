using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Knockback : MonoBehaviour
{
    PlayerEntity player;
    Rigidbody2D thisRigidbody;

    [SerializeField] AnimationCurve curve;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindObjectOfType<PlayerEntity>();

        thisRigidbody = GetComponent<Rigidbody2D>();
    }

    [SerializeField] float length = 1;
    float time = float.MaxValue;
    float knockback;
    private void Update()
    {
        if (time > length)
            return;

        time += Time.deltaTime;
        transform.position = (Vector2.MoveTowards(transform.position, player.transform.position, -knockback * Time.deltaTime * curve.Evaluate(time / length)));
    }

    public void Pushback(float newKnockback)
    {
        time = 0;
        knockback = newKnockback;
    }
}
