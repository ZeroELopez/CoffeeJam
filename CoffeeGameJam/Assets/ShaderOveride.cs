using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaderOveride : MonoBehaviour
{
    SpriteRenderer sprite;
    Material material;
    // Start is called before the first frame update
    [SerializeField]FullScreenPassRendererFeature feature;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        //material = sprite.material;

        material = feature.passMaterial;
    }
    public static float Saturation;
    // Update is called once per frame
    void Update()
    {
        material.SetFloat("_Saturation", Saturation);


    }
}
