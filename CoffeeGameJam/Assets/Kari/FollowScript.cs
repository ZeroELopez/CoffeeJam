using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowScript : MonoBehaviour
{
    public Transform followObj;
    Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - followObj.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = followObj.position + offset;
    }
}
