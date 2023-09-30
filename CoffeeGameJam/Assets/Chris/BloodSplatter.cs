using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events
using UnityEngine;
using JetBrains.Annotations;
using Assets.Scripts.Base.Events;
using Unity.VisualScripting;

public class BloodSplatter : MonoBehaviour
{
    public GameObject Blood;
    EnemyEntity enemy;

    public void Update()
    {
        if (enemy == )
            Instantiate(Blood.transform);
    }

}
