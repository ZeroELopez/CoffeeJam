using Assets.Scripts.Base.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScreen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        EventHub.Instance.PostEvent(new HideHealthbar());   
    }

    public void TryAgain()
    {
        EventHub.Instance?.PostEvent(new TryAgain());
    }
    public void ExitToMainMenu()
    {
        EventHub.Instance?.PostEvent(new ExitToMainMenu());
    }
}
