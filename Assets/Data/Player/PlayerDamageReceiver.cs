using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageReceiver : DamageReceiver
{
    protected override void OnDead()
    {
        GameManager.Instance.OverGame();
    }
  
    protected override void LoadCollider()
    {
        base.LoadCollider();
        this._collider.radius = 1f;

    }

    protected override void Despawn()
    {
        
    }
}
