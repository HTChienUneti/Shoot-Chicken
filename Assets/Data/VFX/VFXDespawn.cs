using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXDespawn : DespawnByTime
{
    protected override void DespawnObj()
    {
        base.DespawnObj();
        VFXSpawner.Instance.Despawn(transform.parent);
    }
}
