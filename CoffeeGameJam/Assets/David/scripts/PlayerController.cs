//Basic Character Movement
//Last updated 9/18/23 - David


using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class movement : MonoBehaviour
{
    public float movSpeed;
    private bool isMoving;

    private Vector2 input;

    private void Update()
    {
        if (!isMoving)
        {
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");

            if (input != Vector2.zero)
            {
                var movPos = transform.position;

                movPos.x += input.x;
                movPos.y += input.y;

                StartCoroutine(Move(movPos));

            }
        }
    }
    IEnumerator Move(Vector3 movPos)
    {
        isMoving= true;

        while((movPos - transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            transform.position = Vector3.MoveTowards(transform.position, movPos, movSpeed * Time.deltaTime);
            yield return null;
        }
        transform.position = movPos;

        isMoving= false;
    }
}
