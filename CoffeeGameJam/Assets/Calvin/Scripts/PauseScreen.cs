using Assets.Scripts.Base.Events;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScreen : MonoBehaviour, ISubscribable<TogglePause>
{
    [SerializeField]
    private GameObject PauseAssets;
    private bool isPaused;

    public void HandleEvent(TogglePause evt)
    {
        isPaused = !isPaused;

        if(isPaused)
        {
            Time.timeScale = 0;
            PauseAssets.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            PauseAssets.SetActive(false);
        }
    }

    public void Subscribe()
    {
        EventHub.Instance.Subscribe(this);
    }

    public void Unsubscribe()
    {
        EventHub.Instance.Unsubscribe(this);
    }

    void Start()
    {
        isPaused = false;
        Subscribe();
    }
}
