using Assets.Scripts.Base.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>, ISubscribable<TryAgain>, ISubscribable<ExitToMainMenu>
{
    private string lastLevelLoaded;
    public string LastLevelLoaded
    {
        get { return lastLevelLoaded; }
        set
        {
            if (!string.IsNullOrEmpty(value))
            {
                lastLevelLoaded = value;
            }
        }
    }
    public void HandleEvent(TryAgain evt)
    {
        SceneLoaderModule.LoadLevel(LastLevelLoaded);
    }

    public void HandleEvent(ExitToMainMenu evt)
    {
        SceneLoaderModule.LoadLevel("MainMenu");
    }

    public void Subscribe()
    {
        EventHub.Instance.Subscribe<TryAgain>(this);
        EventHub.Instance.Subscribe<ExitToMainMenu>(this);
    }

    public void Unsubscribe()
    {
        EventHub.Instance.Unsubscribe<TryAgain>(this);
        EventHub.Instance.Unsubscribe<ExitToMainMenu>(this);
    }

    void Start()
    {
        SetInstance(this);
        Subscribe();
    }
}
