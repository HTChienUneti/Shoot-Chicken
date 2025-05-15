using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipShooter : EnemyShooter
{
    protected override void ResetValue()
    {
        base.ResetValue();
        this.shootDelay = 4f;
    }
}
