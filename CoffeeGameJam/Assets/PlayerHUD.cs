using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerHUD : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI temporaryIndicator;

    [SerializeField]
    private PlayerEntity playerToTrack;

    public void Start()
    {
        playerToTrack.OnHealthChanged += UpdateHUD;
        UpdateHUD();
    }
    public void UpdateHUD()
    {
        temporaryIndicator.SetText("Health: " + playerToTrack.CurrentHealth + " / " + playerToTrack.BaseHealth);
    }    
}
