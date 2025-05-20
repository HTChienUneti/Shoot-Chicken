using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BulletImpact : DamagingObjImpact
{
    [SerializeField] protected BulletCtrl bulletCtrl;
    protected override void ResetValue()
    {
        base.ResetValue();
        this._collider.center = new Vector3(0.02f, -.1f, 0);
        this._collider.radius = 0.1f;
     
    }
    protected override bool ImpactExcluded(Collider collision)
    {
        if (base.ImpactExcluded(collision) || this.ImpactShooter(collision)) return true ;
        return false;
    }
    protected virtual bool ImpactShooter(Collider collision)
    {
        return collision.GetComponent<DamageReceiver>().transform.parent == this.bulletCtrl.Shooter;
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
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadBulletCtrl();
    }
    protected virtual void LoadBulletCtrl()
    {
        if (this.bulletCtrl != null) return;
        this.bulletCtrl = GetComponentInParent<BulletCtrl>();
        if (bulletCtrl)
        {
            Debug.Log("succes");
        }
        else
        {
            Debug.Log("NO");
        }
        Debug.LogWarning(transform.name + " LoadBulletCtrl", gameObject);
    }

    protected override void SendDamage(DamageReceiver damageReceiver)
    {
       this.bulletCtrl.DamageSender.SendDamage(damageReceiver);
    }
}
