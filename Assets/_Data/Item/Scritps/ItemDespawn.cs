using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDespawn : DespawnByDistance
{
    protected override void ResetValue()
    {
        base.ResetValue();
        this.maxDistance = 15f;
    }
    protected override void GetTarget()
    {
        this.target = Camera.main.transform;
    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadCamera();
    }
    protected virtual void LoadCamera()
    {
        if (this.target != null) return;
        this.target = Camera.main.transform;
        Debug.Log(transform.name + " LoadCamera", gameObject);
    }

    protected override void DespawnObj()
    {
        ItemSpawner.Instance.Despawn(transform.parent);
    }
}
