using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnparentAtRuntime : MonoBehaviour
{
    private void Start()
    {
        transform.parent = null;
    }
}
