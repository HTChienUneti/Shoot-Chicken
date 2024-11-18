using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class HittableObjectImpact : ObjImpact
{
    [Header("Shootedable Obj Impact")]
    [SerializeField] protected ShootedableObjCtrl shootableObjCtrl;
    protected virtual void SendDamage(DamageReceiver damageReceiver)
    {
        this.shootableObjCtrl.DamageSender.Send(damageReceiver);
    }
    protected override void OnImpact(DamageReceiver damageReceiver)
    {
        this.Despawn();
        this.SendDamage(damageReceiver);
    }
    protected override bool ImpactExcluded(Collider collision)
    {
        base.ImpactExcluded(collision);
        if(this.ImpactTeammates(collision)) return true;
        return false;
    }
  
    protected abstract void Despawn();

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadCollier();
        this.LoadRigid();
        this.LoadShootableObjCtrl();
    }
    protected virtual void LoadShootableObjCtrl()
    {
        if (this.shootableObjCtrl != null) return;
        this.shootableObjCtrl = transform.parent.GetComponent<ShootedableObjCtrl>();
        Debug.Log(transform.name + " :LoadShootableObjCtrl", gameObject);
    }
}
