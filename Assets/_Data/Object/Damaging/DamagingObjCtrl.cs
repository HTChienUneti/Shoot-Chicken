using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DamagingObjCtrl : MyMonoBehaviour
{
    [SerializeField] protected DamageSender damageSender;
    public DamageSender DamageSender=>damageSender;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadDamageSender(); 
    }
 
    protected virtual void LoadDamageSender()
    {
        if (this.damageSender != null) return;
        this.damageSender = GetComponentInChildren<DamageSender>();
        Debug.LogWarning(transform.name + " :LoadDamageSender", gameObject);
    }
}
