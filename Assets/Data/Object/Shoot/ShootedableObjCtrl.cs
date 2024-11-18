using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootedableObjCtrl : MyMonoBehaviour
{
    [SerializeField] protected DamageReceiver damageReceiver;
    [SerializeField] protected DamageSender damageSender;
    public DamageReceiver DamageReceiver => damageReceiver;
    public DamageSender DamageSender=>damageSender;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadDamageReceiver();
        this.LoadDamageSender();
    }
    protected virtual void LoadDamageSender()
    {
        if (this.damageSender != null) return;
        this.damageSender = GetComponentInChildren<DamageSender>();
        Debug.LogWarning(transform.name + " :LoadDamageSender", gameObject);
    }
    protected virtual void LoadDamageReceiver()
    {
        if (this.damageReceiver != null) return;
        this.damageReceiver = GetComponentInChildren<DamageReceiver>();
        Debug.LogWarning(transform.name + " :LoadDamageReceiver", gameObject);
    }
}
