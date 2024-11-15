using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DespawnByDistance : Despawn
{
    [Header("DespawnByDistance")]
    [SerializeField] protected Transform target;
    [SerializeField] protected float distance;
    [SerializeField] protected float maxDistance=100;
    protected override void Start()
    {
        base.Start();
        this.GetTarget();
    }
    protected override bool TryingDespawn()
    {
        this.distance = Vector3.Distance(transform.parent.position, target.position);
        if (distance < maxDistance) return false;
        return true;    
    }
    protected abstract void GetTarget();
}
