using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(SphereCollider))]
public abstract class ShootableObjImpact: ShootableObjAbstract
{
    [Header("Shootable Obj Impact")]
    [SerializeField] protected Rigidbody _rigid;
    [SerializeField] protected SphereCollider _collider;
    protected virtual void OnTriggerEnter(Collider collision)
    {
       // if(this.CheckImpactSelf(collision)) return;
  //      this.CreateVFXImpact();
       // this.Despawn();
    //    this.GetDamageReceiver(collision);
 //       DamageReceiver damageReceiver = this.GetDamageReceiver(collision);
       // if (damageReceiver == null) return;
//this.SendDamage(damageReceiver);
        
    }
    //protected virtual void CreateVFXImpact()
    //{
    //    string impact_1 = VFXSpawner.impact_1;
    //    Transform vfx = VFXSpawner.Instance.Spawn(impact_1, transform.position, transform.rotation);
    //    if (vfx == null) return;
    //    vfx.gameObject.SetActive(true);
    //}
    ////protected abstract bool CheckImpactSelf(Collider collision);
    //protected virtual DamageReceiver GetDamageReceiver(Collider collision)
    //{
    //    ShootableObjImpact objImpact = collision.GetComponent<ShootableObjImpact>();
    //    return objImpact.shootableObjCtrl.DamageReceiver;
    //}
    //protected virtual void SendDamage(DamageReceiver damageReceiver)
    //{
        
    //}
    //protected abstract void Despawn();

    //protected override void LoadComponent()
    //{
    //    base.LoadComponent();
    //    this.LoadCollier();
    //    this.LoadRigid();
    //}
    //protected virtual void LoadCollier()
    //{
    //    if (this._collider != null) return;
    //    this._collider = GetComponent<SphereCollider>();
    //    this._collider.radius = .2f;
    //    this._collider.isTrigger = true;
    //    Debug.LogWarning(transform.name + ": LoadCollier", gameObject);
    //}
    //protected virtual void LoadRigid()
    //{
    //    if (this._rigid != null) return;
    //    this._rigid = GetComponent<Rigidbody>();
    //    this._rigid.useGravity = false;
    //    Debug.LogWarning(transform.name + ": LoadRigid", gameObject);
    //}
}
