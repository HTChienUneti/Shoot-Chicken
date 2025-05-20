using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipShooter : EnemyShooter
{
    protected override void ResetValue()
    {
        base.ResetValue();
        this.shootDelay = Random.Range(2f,4f);
    }
}
