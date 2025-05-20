using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDespawn : DespawnByDistance
{
    protected override void DespawnObj()
    {
        
        BulletSpawner.Instance.Despawn(transform.parent);
    }
    protected override void GetTarget()
    {
        this.target = Camera.main.transform;
    }

}
