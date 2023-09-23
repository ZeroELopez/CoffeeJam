using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UsableObject : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public bool usable = true;

    public UnityEvent onRespawn;
    public void Respawn()
    {
        usable = true;
        onRespawn?.Invoke();
    }

    public UnityEvent<SpriteRenderer> onUsed;
    public void Use()
    {
        usable = false;
        onUsed?.Invoke(spriteRenderer);
    }

    public UnityEvent onStart;
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        usable = true;
        onStart?.Invoke();
    }

}
