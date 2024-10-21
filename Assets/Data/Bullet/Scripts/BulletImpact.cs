using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BulletImpact : ObjImpact
{
    [Header("Bullet Impact")]
    [SerializeField] protected BulletCtrl bulletCtrl;
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
        this.bulletCtrl.BulletDamageSender.Send(damageReceiver);
    }
    protected override void LoadCollier()
    {
        base.LoadCollier();
        this.LoadBulletCtrl();
    }
    protected virtual void LoadBulletCtrl()
    {
        if (this.bulletCtrl != null) return;
        this.bulletCtrl = transform.parent.GetComponent<BulletCtrl>();  
  
        Debug.LogWarning(transform.name + ": LoadBulletCtrl", gameObject);
    }
 
}
