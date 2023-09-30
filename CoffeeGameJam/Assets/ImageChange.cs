using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageChange : MonoBehaviour
{
    Image spriteRenderer;
    [SerializeField] Sprite[] sprites;
    [SerializeField] float[] levels;
    [SerializeField] PlayerEntity entity;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<Image>();
        entity = GameObject.FindFirstObjectByType<PlayerEntity>();
    }

    // Update is called once per frame
    void Update()
    {
        if (entity == null)
            entity = GameObject.FindFirstObjectByType<PlayerEntity>();

        float perc = (float)entity.CurrentHealth / (float)entity.BaseHealth;
        float low, high;
        Debug.Log(perc);
        for (int i = 0; i < levels.Length; i++)
        {
            if (i == 0)
                low = 0;
            else
                low = levels[i - 1];

            high = levels[i];

            if (perc >= low && perc <= high)
                spriteRenderer.sprite = sprites[i];
        }
    }
}
