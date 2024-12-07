using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;

using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(SphereCollider))]
public abstract class DamagingObjImpact: ObjImpact
{
    [Header("Damaging Obj Impact")]
    [SerializeField] protected DamagingObjCtrl damagingObjCtrl;
  
    protected override bool ImpactExcluded(Collider collision)
    {
        if(base.ImpactExcluded(collision) || this.ImpactShooter(collision)) return true;

        return false;
    }
    protected virtual bool ImpactShooter(Collider collision)
    {
        if (this.damagingObjCtrl.Shooter == null) return false;
        if(collision.transform.parent == this.damagingObjCtrl.Shooter) return true;
        return false;   
    }
    protected override void OnImpact(DamageReceiver damageReceiver)
    {
        this.Despawn();

        this.SendDamage(damageReceiver);
    }
    protected virtual void SendDamage(DamageReceiver damageReceiver)
    {
        if (!damageReceiver) return;
        this.damagingObjCtrl.DamageSender.Send(damageReceiver);        
    }
    protected abstract void Despawn();
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadDamagingObjCtrl();
    }
    protected virtual void LoadDamagingObjCtrl()
    {
        if (this.damagingObjCtrl != null) return;
        this.damagingObjCtrl = transform.parent.GetComponent<DamagingObjCtrl>();
        Debug.Log(transform.name + " :DamagingObjCtrl", gameObject);
    }
}
