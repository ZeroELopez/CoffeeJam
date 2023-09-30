using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        follow = transform.parent;
        transform.parent = null;
    }
    Transform follow;
   
    // Update is called once per frame
    void Update()
    {
        transform.position = follow.position;
        transform.localScale = follow.lossyScale;
        transform.rotation = new Quaternion();
    }
}
