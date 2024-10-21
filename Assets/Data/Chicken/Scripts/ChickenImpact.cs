using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenImpact : ObjImpact
{
    [SerializeField] protected ChickenCtrl chickenCtrl;
    protected override bool CheckImpactSelf(Collider other)
    {

        //Check impact with chicken and egg
        if (other.transform.parent.GetComponent<ChickenCtrl>()
            || other.transform.parent.GetComponent<EggCtrl>()
            || other.transform.parent.GetComponent<BulletCtrl>())return true;
        return false;
    }

    protected override void Despawn()
    {
        ChickenSpawner.Instance.Despawn(transform.parent);
    }

    protected override void SendDamage(DamageReceiver damageReceiver)
    {
        this.chickenCtrl.DamageSender.Send(damageReceiver);
    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadChickenCtrl();
    }
    protected virtual void LoadChickenCtrl()
    {
        if (this.chickenCtrl != null) return;
        this.chickenCtrl = transform.parent.GetComponent<ChickenCtrl>();
        Debug.Log(transform.name + " :LoadChickenCtrl", gameObject);
    }
    protected override void LoadCollier()
    {
        base.LoadCollier();
        this._collider.radius = .5f;
    }
    //protected override void CreateVFXImpact()
    //{
    //    string impact_1 = VFXSpawner.impact_1;
    //    Transform vfx = VFXSpawner.Instance.Spawn(impact_1, transform.position, transform.rotation);
    //    if (vfx == null) return;
    //    vfx.gameObject.SetActive(true);
    //}
}
