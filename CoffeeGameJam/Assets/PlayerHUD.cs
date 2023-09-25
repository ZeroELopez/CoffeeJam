using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerHUD : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI temporaryIndicator;

    [SerializeField]
    public PlayerEntity PlayerToTrack;
        
    public void UpdateHUD()
    {
        temporaryIndicator.SetText("Health: " + PlayerToTrack.CurrentHealth + " / " + PlayerToTrack.BaseHealth);
    }    
}
