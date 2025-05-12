using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDamageReceiver : EnemyDamageReceiver
{
    [SerializeField] protected BossCtrl bossCtrl;
    protected override void LoadCollider()
    {
        base.LoadCollider();
        this._collider.radius = 2f;
    }
    public override void ReduceHp(int hp)
    {
        base.ReduceHp(hp);
        this.bossCtrl.HealthBar.ReduceSliderValue(this.currentHp,this.hpMax);
    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadBossCtrl();
    }
protected virtual void LoadBossCtrl()
    {
        if (this.bossCtrl != null) return;
        this.bossCtrl = transform.parent.GetComponent<BossCtrl>();
        Debug.LogWarning(transform.name + ": LoadBossCtrl", gameObject);
    }
}
