using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BulletImpact : DamagingObjImpact
{
    protected override void ResetValue()
    {
        base.ResetValue();
        this._collider.center = new Vector3(0.02f, -.1f, 0);
        this._collider.radius = 0.1f;
     
    }
    protected override void OnImpact(DamageReceiver damageReceiver)
    {
        base.OnImpact(damageReceiver);
        BulletImpactManager.Instance.SetImpact();
  
    }
    protected override void Despawn()
    {
        BulletSpawner.Instance.Despawn(transform.parent);
    }

    protected override bool ImpactTeammates(Collider collider)
    {
        if(this.ImpactBullet(collider)) return true;    
        return false;
    }
    protected virtual bool ImpactBullet(Collider collider)
    {
        if (collider.transform.parent.GetComponent<EnemyBulletCtrl>()) return true;
        return false;
    }

}
