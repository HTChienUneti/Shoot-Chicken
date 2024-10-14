using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenCtrl : MyMonoBehaviour
{
    [SerializeField] protected ChickenDamageReceiver damageReceiver;
    public ChickenDamageReceiver DamageReceiver =>damageReceiver;
    [SerializeField] protected ChickenMovement chickenMovement;
    public ChickenMovement ChickenMovement => chickenMovement;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadDamageReceiver();
        this.LoadChickenMovement();
    }
    protected virtual void LoadChickenMovement()
    {
        if (this.chickenMovement != null) return;
        this.chickenMovement = GetComponentInChildren<ChickenMovement>();

        Debug.LogWarning(transform.name + ": LoadChickenMovement", gameObject);
    }
    protected virtual void LoadDamageReceiver()
    {
        if (this.damageReceiver != null) return;
        this.damageReceiver = GetComponentInChildren<ChickenDamageReceiver>();
     
        Debug.LogWarning(transform.name + ": LoadDamageReceiver", gameObject);
    }
}
