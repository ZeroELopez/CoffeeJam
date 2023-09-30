using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitFreeze : Singleton<HitFreeze>
{
    private void Awake()
    {
        SetInstance(this);
    }
    public void StartHitFreeze(int frames) => StartCoroutine("HitStop", frames);

    public IEnumerator HitStop(int frames)
    {
        Debug.Log("In HitFreeze");

        Time.timeScale = 0.0001f;

        yield return new WaitForSecondsRealtime((float)frames * .016f);

        Time.timeScale = 1;
    }
}
