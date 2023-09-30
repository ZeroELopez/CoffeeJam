using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    [SerializeField]
    protected int baseHealth;
    public int BaseHealth => baseHealth;

    public Action OnHealthChanged;

    [SerializeField]
    private int currentHealth;
    public int CurrentHealth
    {
        get 
        {  
            return currentHealth; 
        }
        set 
        {
            if (currentHealth != value)
            {
                currentHealth = value;
                OnHealthChanged?.Invoke();
            }

            if(currentHealth <= 0)
            {
                OnDeath();
            }
        }
    }

    [SerializeField]
    protected int invincibilityFrames;

    protected bool isInvincible;
    public bool IsInvincible => isInvincible;

    public void Start()
    {
        currentHealth = baseHealth;
        isInvincible = false;
        Initialize();
    }

    protected abstract void Initialize();

    public abstract void OnDeath();

    public IEnumerator Invincibility()
    {
        isInvincible = true;

        Debug.Log("Invincibility on");
        yield return new WaitForSeconds(invincibilityFrames / 60f);

        isInvincible = false;
        Debug.Log("Invincibility off");
    }
}
