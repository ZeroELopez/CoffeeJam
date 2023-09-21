using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class FollowScript : MonoBehaviour
{
    public Transform followObj;
    Vector3 offset;

    [SerializeField] float speed;
    [SerializeField] AnimationCurve curve;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - followObj.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(
            transform.position, 
            followObj.position + offset,
            speed * curve.Evaluate(Vector3.Distance(transform.position, followObj.position + offset)));
    }
}
