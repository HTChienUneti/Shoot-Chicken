using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.MPE;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(SphereCollider))]
public abstract class DamagingObjImpact: ObjImpact
{
    [Header("Damaging Obj Impact")]
    [SerializeField] protected DamagingObjCtrl damagingObjCtrl;
  
    protected override bool ImpactExcluded(Collider collision)
    {
        base.ImpactExcluded(collision);
        if (this.ImpactShooter(collision)) return true; 
        return false;
    }
    protected virtual bool ImpactShooter(Collider collision)
    {
        if(collision.transform.parent == this.damagingObjCtrl.Shooter) return true;
        return false;   
    }
    protected override  void  OnImpact(DamageReceiver damageReceiver)
    {
        this.Despawn();
        Debug.Log(damageReceiver);
        this.SendDamage(damageReceiver);
    }
    protected override void CreateVFXImpact()
    {
        string impact_1 = VFXSpawner.impact_1;
        Transform vfx = VFXSpawner.Instance.Spawn(impact_1, transform.position, transform.rotation);
        if (vfx == null) return;
        vfx.gameObject.SetActive(true);
    }
    protected virtual void SendDamage(DamageReceiver damageReceiver)
    {
        this.damagingObjCtrl.DamageSender.Send(damageReceiver);        
    }
    protected abstract void Despawn();
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.DamagingObjCtrl();
    }
    protected virtual void DamagingObjCtrl()
    {
        if (this.damagingObjCtrl != null) return;
        this.damagingObjCtrl = transform.parent.GetComponent<DamagingObjCtrl>();
        Debug.Log(transform.name + " :DamagingObjCtrl", gameObject);
    }
}
