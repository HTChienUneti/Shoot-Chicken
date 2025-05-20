using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletDespawn : DespawnByDistance
{
    protected override void DespawnObj()
    {
        EnemyBulletSpawner.Instance.Despawn(transform.parent);
    }
    protected override void GetTarget()
    {
        this.target = Camera.main.transform;
    }
}
