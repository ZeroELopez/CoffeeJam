using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetSaturation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ShaderOveride.Saturation = 1f;

    }
}
