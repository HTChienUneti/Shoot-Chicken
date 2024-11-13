using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BulletImpact : DamagingObjImpact
{
    protected override void ResetValue()
    {
        base.ResetValue();
        this._collider.radius = 0.4f;
     //   this._collider.center= new Vector3(0,1,0);
    }
    protected override void Despawn()
    {
        BulletSpawner.Instance.Despawn(transform.parent);
    }
    protected override bool CheckImpactSelf(Collider collision)
    {
        if (collision.transform.parent.GetComponent<PlayerCtrl>()
            ||collision.transform.parent.GetComponent<ItemCtrl>())
             return true;
        return false;   
    }
    protected override void SendDamage(DamageReceiver damageReceiver)
    {
        this.damagingObjCtrl.DamageSender.Send(damageReceiver);
    }
 
}
