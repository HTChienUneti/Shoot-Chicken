using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(SphereCollider))]
public abstract class DamagingObjImpact: ObjImpact
{
   // [Header("Damaging Obj Impact")]
    protected override void OnImpact(DamageReceiver damageReceiver)
    {
        this.Despawn();
        if(damageReceiver != null)
        {
            this.SendDamage(damageReceiver);
        }
        
    }
    protected abstract void SendDamage(DamageReceiver damageReceiver);
    protected abstract void Despawn();
}
