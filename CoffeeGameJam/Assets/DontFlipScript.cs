using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontFlipScript : MonoBehaviour
{
    // Start is called before the first frame update

    private void Update()
    {
        if (transform.lossyScale.x > 0)
        {
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }
    }

}
