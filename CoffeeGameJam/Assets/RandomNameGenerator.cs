using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RandomNameGenerator : MonoBehaviour
{
    TextMeshProUGUI gui;

    string firstName;



    [SerializeField] string[] names;
    [SerializeField] string[] places;
    [SerializeField] string inbetween;
    // Start is called before the first frame update
    void Start()
    {
        gui = GetComponent<TextMeshProUGUI>();
        firstName = names[Random.Range(0, names.Length)];

        gui.text = firstName + inbetween + places[Random.Range(0, places.Length)];

        
    }

    public void SendName()
    {
        EntityEventTracker.player.GetComponentInChildren<EntityEventTracker>().PlayVoice(firstName);
    }
}
