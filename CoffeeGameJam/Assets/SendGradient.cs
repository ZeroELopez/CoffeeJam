using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class SendGradient : MonoBehaviour
{
    [SerializeField] Gradient gradient;


    [SerializeField] Gradient[] multiGradients;

    [SerializeField] Material material;

    [SerializeField] Texture2D texture;
    // Start is called before the first frame update
    void Start()
    {
        texture = new Texture2D(255, 1);

        if (multiGradients.Length > 0)
            gradient = multiGradients[Random.Range(0, multiGradients.Length - 1)];
    }

    // Update is called once per frame
    void Update()
    {
        if (texture == null)
            texture = new Texture2D(255, 1);

        for (int i = 0; i < texture.width; i++)
            texture.SetPixel(i, 0, gradient.Evaluate((float)i / (float)texture.width));

        texture.Apply();

        material.SetTexture("_Palette", texture);
    }
}
