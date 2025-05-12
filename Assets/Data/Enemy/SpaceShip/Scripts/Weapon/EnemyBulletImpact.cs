using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyBulletImpact : DamagingObjImpact
{
    protected override void Despawn()
    {
        EnemyBulletSpawner.Instance.Despawn(transform.parent);
    }
    protected override bool ImpactExcluded(Collider collision)
    {
        base.ImpactExcluded(collision);
        if (this.ImpactSquad(collision)) return true;
        return base.ImpactExcluded(collision);
    }
    protected virtual bool ImpactSquad(Collider collision)
    {
        if (collision.transform.parent.GetComponent<SpaceShipEnemyCtrl>()) return true;
        return false;
    }

    protected override bool ImpactTeammates(Collider collider)
    {
        if (this.ImpactEgg(collider)) return true;
        return false;
    }
    protected virtual bool ImpactEgg(Collider collider)
    {
        if (collider.transform.parent.GetComponent<SpaceShipEnemyCtrl>()) return true;
        return false;   
    }
}
