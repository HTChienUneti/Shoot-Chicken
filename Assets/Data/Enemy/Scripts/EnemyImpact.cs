using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyImpact : DamagingObjImpact
{
    protected override void Despawn()
    {
        EnemySpawner.Instance.Despawn(transform.parent);
    }

    protected override bool ImpactTeammates(Collider collider)
    {
        if(collider.transform.parent.GetComponent<EnemyCtrl>()) return true;
        return false;
    }
}
