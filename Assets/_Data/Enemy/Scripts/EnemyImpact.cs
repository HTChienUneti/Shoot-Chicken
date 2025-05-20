using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyImpact : DamagingObjImpact
{
    [SerializeField] protected EnemyCtrl EnemyCtrl;
    protected override void Despawn()
    {
        EnemySpawner.Instance.Despawn(transform.parent);
    }

    protected override bool ImpactTeammates(Collider collider)
    {
        if(collider.transform.parent.GetComponent<EnemyCtrl>()) return true;
        return false;
    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadEnemyCtrl();
    }
    protected virtual void LoadEnemyCtrl()
    {
        if (this.EnemyCtrl != null) return;
        this.EnemyCtrl = GetComponentInParent<EnemyCtrl>();
        Debug.Log(transform.name + " LoadEnemyCtrl", gameObject);
    }

    protected override void SendDamage(DamageReceiver damageReceiver)
    {
        this.EnemyCtrl.DamageSender.SendDamage(damageReceiver);
    }
}
