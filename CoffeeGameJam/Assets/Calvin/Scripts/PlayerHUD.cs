using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.EventSystems.EventTrigger;

public class PlayerHUD : MonoBehaviour
{
    [SerializeField]
    private Image indicator;

    [SerializeField]
    public PlayerEntity PlayerToTrack;

    public void UpdateHUD()
    {
        indicator.fillAmount = (float)PlayerToTrack.CurrentHealth / (float)PlayerToTrack.BaseHealth;
    }
}
