using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class HittableObjectImpact : ObjImpact
{
    [Header("Shootedable Obj Impact")]
    [SerializeField] protected HittableObjCtrl shootableObjCtrl;
    protected override void OnImpact(DamageReceiver damageReceiver)
    {
        this.Despawn();
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
        this.shootableObjCtrl = transform.parent.GetComponent<HittableObjCtrl>();
        Debug.Log(transform.name + " :LoadShootableObjCtrl", gameObject);
    }
}
