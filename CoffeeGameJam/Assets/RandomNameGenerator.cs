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

    string firstName;
    // Start is called before the first frame update
    void Start()
    {
        gui = GetComponent<TextMeshProUGUI>();
        firstName = names[Random.Range(0, names.Length)];
        gui.text =  firstName+ inbetween + places[Random.Range(0, places.Length)];

        
    }

    public void DeathVoiceLine()
    {
        AudioManager.PlaySound(firstName, EntityEventTracker.player.GetComponentInChildren<AudioSource>());
    }
}
