using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageReceiver : DamageReceiver
{
    [SerializeField] PlayerCtrl playerCtrl;
    protected override void OnDead()
    {
        GameManager.Instance.OverGame();
    }
    public override void ReduceHp(int hp)
    {
        base.ReduceHp(hp);
        if (this.currentHp <= 0) return;
        this.Revive();
    }
    protected override string GetVfxName()
    {
        return VFXSpawner.impact_1;
    }

    protected virtual void Revive()
    {
        this.playerCtrl.PlayerRevive.Revive();
    }
    protected override void LoadCollider()
    {
        base.LoadCollider();
        this._collider.radius = 1f;
    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadPlayerCtrl();
    }
    protected virtual void LoadPlayerCtrl()
    {
        if (this.playerCtrl != null) return;
        this.playerCtrl = transform.parent.GetComponent<PlayerCtrl>();
        Debug.LogWarning(transform.name + ": LoadPlayerCtrl", gameObject);
    }
}
