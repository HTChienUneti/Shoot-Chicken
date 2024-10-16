using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggDespawn : DespawnByDistance
{
    protected override void DespawnObj()
    {
        base.DespawnObj();
        EggSpawner.Instance.Despawn(transform.parent);
    }
    protected override void GetTarget()
    {
        this.target = Camera.main.transform;
    }
}
