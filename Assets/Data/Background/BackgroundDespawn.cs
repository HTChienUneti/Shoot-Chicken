using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundDespawn : DespawnByDistance
{

    protected override void GetTarget()
    {
        this.target = Camera.main.transform;
    }
    protected override void DespawnObj()
    {
        BackgroundSpawner.Instance.Despawn(transform.parent);
    
    }

}
