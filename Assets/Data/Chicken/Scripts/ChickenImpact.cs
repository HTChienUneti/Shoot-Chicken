using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenImpact : HittableObjectImpact
{
    protected override void Despawn()
    {
        ChickenSpawner.Instance.Despawn(transform.parent);
    }

    protected override bool ImpactTeammates(Collider collider)
    {
        if (collider.transform.parent.GetComponent<ChickenCtrl>()) return true;
        return false;
    }
}
