using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HittableObjCtrl : MyMonoBehaviour, IGameActiveState
{
    [SerializeField] protected DamageReceiver damageReceiver;
    public DamageReceiver DamageReceiver => damageReceiver;
    protected override void Start()
    {
        base.Start();
        GameActiveState.Instance.Add(this);
    }

    public virtual void EnterState()
    {
        
    }

    public virtual void ExcuseState()
    {
    }


    public virtual void ExitState()
    {
        
    }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadDamageReceiver();
    //    this.LoadDamageSender();
    }
    protected virtual void LoadDamageReceiver()
    {
        if (this.damageReceiver != null) return;
        this.damageReceiver = GetComponentInChildren<DamageReceiver>();
        Debug.LogWarning(transform.name + " :LoadDamageReceiver", gameObject);
    }
}
