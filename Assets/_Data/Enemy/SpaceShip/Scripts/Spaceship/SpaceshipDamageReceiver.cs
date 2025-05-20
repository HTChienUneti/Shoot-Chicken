using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipDamageReceiver : EnemyDamageReceiver
{
    [SerializeField] protected SpaceShipEnemyCtrl chickenCtrl;

   protected override void LoadCollider()
    {
        base.LoadCollider();
        this._collider.radius = .1f;
    }
 
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadChickenCtrl();
    }
    protected virtual void LoadChickenCtrl()
    {
        if (this.chickenCtrl != null) return;
        this.chickenCtrl = transform.parent.GetComponent<SpaceShipEnemyCtrl>();
        Debug.LogWarning(transform.name + ": LoadChickenCtrl", gameObject);
    }

  
}
