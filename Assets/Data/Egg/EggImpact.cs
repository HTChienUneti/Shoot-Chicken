using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EggImpact : ObjImpact
{
    [Header("Egg Impact")]
    [SerializeField] protected EggCtrl eggCtrl;
    protected override void Despawn()
    {
        EggSpawner.Instance.Despawn(transform.parent);
    }
    protected override bool CheckShootSelf(Collider2D collision)
    {
        return this.eggCtrl.Shooter.ChickenCtrl.DamageReceiver.Collider == collision;
    }
    protected override void SendDamage()
    {
        this.eggCtrl.EggDamageSender.Send(this.damageReceiver);
    }
    protected override void LoadCollier()
    {
        base.LoadCollier();
        this.LoadEggCtrl();
    }
    protected virtual void LoadEggCtrl()
    {
        if (this.eggCtrl != null) return;
        this.eggCtrl = transform.parent.GetComponent<EggCtrl>();  
  
        Debug.LogWarning(transform.name + ": LoadEggCtrl", gameObject);
    }
}
