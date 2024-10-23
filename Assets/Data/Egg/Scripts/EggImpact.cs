using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EggImpact : DamagingObjImpact
{
    //[Header("Egg Impact")]
    protected override void Despawn()
    {
        EggSpawner.Instance.Despawn(transform.parent);
    }
    //protected override void CreateVFXImpact()
    //{
    //    string impact_1 = VFXSpawner.impact_1;
    //    Transform vfx = VFXSpawner.Instance.Spawn(impact_1, transform.position, transform.rotation);
    //    if (vfx == null) return;
    //    vfx.gameObject.SetActive(true);
    //}
    protected override bool CheckImpactSelf(Collider other)
    {
        if (other.transform.parent.GetComponent<ChickenCtrl>()) return true;
        return false;
    }
    protected override void SendDamage(DamageReceiver damageReceiver)
    {
        this.damagingObjCtrl.DamageSender.Send(damageReceiver);
    }
}
