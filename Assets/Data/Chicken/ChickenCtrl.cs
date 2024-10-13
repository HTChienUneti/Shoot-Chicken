using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenCtrl : MyMonoBehaviour
{
    [SerializeField] protected ChickenDamageReceiver damageReceiver;
    public ChickenDamageReceiver DamageReceiver =>damageReceiver;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadDamageReceiver();
    }
    protected virtual void LoadDamageReceiver()
    {
        if (this.damageReceiver != null) return;
        this.damageReceiver = GetComponentInChildren<ChickenDamageReceiver>();
     
        Debug.LogWarning(transform.name + ": LoadDamageReceiver", gameObject);
    }
}
