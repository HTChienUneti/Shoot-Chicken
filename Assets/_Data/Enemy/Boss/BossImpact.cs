using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossImpact : EnemyImpact
{
    protected override void ResetValue()
    {
        base.ResetValue();
        this._collider.radius = 1.5f;
    }
}
