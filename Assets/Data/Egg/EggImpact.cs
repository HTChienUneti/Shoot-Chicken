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
    protected override void OnTriggerEnter2D(Collider2D collision)
    {

        //To optimize
        if (collision.transform.CompareTag("Chicken")) return;
        base.OnTriggerEnter2D(collision);
    }
    protected override void CreateVFXImpact()
    {
        string impact_1 = VFXSpawner.impact_1;
        Transform vfx = VFXSpawner.Instance.Spawn(impact_1, transform.position, transform.rotation);
        if (vfx == null) return;
        vfx.gameObject.SetActive(true);
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
