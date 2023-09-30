using Assets.Scripts.Base.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : Singleton<UIManager>, ISubscribable<HideHealthbar>, ISubscribable<ShowHealthbar>
{
    PlayerHUD healthbar;

    public void HandleEvent(HideHealthbar evt)
    {
        healthbar.enabled = false;
    }

    public void HandleEvent(ShowHealthbar evt)
    {
        healthbar.enabled = true;
    }

    public void Subscribe()
    {
        EventHub.Instance.Subscribe<ShowHealthbar>(this);
        EventHub.Instance.Subscribe<HideHealthbar>(this);
    }

    public void Unsubscribe()
    {
        EventHub.Instance.Unsubscribe<ShowHealthbar>(this);
        EventHub.Instance.Unsubscribe<HideHealthbar>(this);
    }

    private void Start()
    {
        DontDestroyOnLoad(this);
        SetInstance(this);

        healthbar = GetComponentInChildren<PlayerHUD>();
        Subscribe();
    }
}
