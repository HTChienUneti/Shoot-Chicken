using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageReceiver : DamageReceiver
{
    protected override void OnDead()
    {
        Debug.LogError("GAME OVER");
    }
    protected override void ResetValue()
    {
        base.ResetValue();
        this.Collider.radius = 0.3f;
    }
}
