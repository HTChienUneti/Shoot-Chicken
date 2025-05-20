using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DespawnByTime : Despawn
{
    [Header("Despawn By Time")]
    [SerializeField] protected float timer;
    [SerializeField] protected float timeMax= 2f;
    protected override void Start()
    {
        base.Start();
    }
    protected override bool TryingDespawn()
    {
        this.timer += Time.fixedDeltaTime;
        if (this.timer < this.timeMax) return false;
        this.timer = 0f;    
        return true;
    }
}
