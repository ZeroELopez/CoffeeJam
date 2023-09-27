using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllAnimatorController : MonoBehaviour
{
    Animator[] allAnimators;
    // Start is called before the first frame update

    [SerializeField]float time = float.MaxValue;
    float effectTime = 1;
    bool effectOn = true;
    private void Start()
    {
        allAnimators = GameObject.FindObjectsOfType<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        if (time > effectTime)
        {
            effectOn = false;
            foreach (Animator a in allAnimators)
            {
if (a == null)
continue;
                a.enabled = true;
                a.speed = 1;
            }
        }
        else
            time += Time.deltaTime;
    }

    public void Freeze(float length)
    {
        effectTime = length;
        time = 0;

        foreach (Animator a in allAnimators)
        {
if (a == null)
continue;
            a.enabled = false;
            a.speed = 0;
        }
    }

}
