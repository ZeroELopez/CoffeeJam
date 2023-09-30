using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RandomNameGenerator : MonoBehaviour
{
    TextMeshProUGUI gui;

    [SerializeField] string[] names;
    [SerializeField] string[] places;
    [SerializeField] string inbetween;
    // Start is called before the first frame update
    void Start()
    {
        gui = GetComponent<TextMeshProUGUI>();

        gui.text = names[Random.Range(0, names.Length)] + inbetween + places[Random.Range(0, places.Length)];

        
    }
}
