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
        this.hpMax = 100;
    }
    //protected override void LoadCollider()
    //{
    //    base.LoadCollider();
    //    this._collider.radius = 1f;
  
    //}

    protected override void Despawn()
    {
        
    }
}
