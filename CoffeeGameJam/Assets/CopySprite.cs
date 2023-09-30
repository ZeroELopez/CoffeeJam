using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopySprite : MonoBehaviour
{
    [SerializeField] SpriteRenderer parentRenderer;
    SpriteRenderer spriteRenderer;

    bool CopyFlip = true;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        spriteRenderer.sprite = parentRenderer.sprite;

        if (CopyFlip)
            spriteRenderer.flipX = parentRenderer.flipX;
    }
}
