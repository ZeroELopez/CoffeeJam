using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class Healthbar : MonoBehaviour
{
    [SerializeField] Image image;

    private void Start()
    {
        image = GetComponent<Image>();
    }
    public Entity entity;

    
    void Update()
    {
        if (entity == null)
            return;

        image.fillAmount = (float)entity.CurrentHealth / (float)entity.BaseHealth;
    }    
}
