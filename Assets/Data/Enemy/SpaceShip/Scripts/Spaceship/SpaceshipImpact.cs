using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipImpact : EnemyImpact
{
    protected override void ResetValue()
    {
        base.ResetValue();
        this._collider.radius = 0.1f;
    }
}
