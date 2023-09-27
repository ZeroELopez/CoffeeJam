using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    Image image;

    private void Start()
    {
        image = GetComponent<Image>();
    }
    [SerializeField] Entity entity;

    // Update is called once per frame
    void Update()
    {
        image.fillAmount = (float)entity.CurrentHealth / (float)entity.BaseHealth;
    }
}
