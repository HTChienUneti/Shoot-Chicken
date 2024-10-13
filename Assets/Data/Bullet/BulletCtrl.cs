using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCtrl : MyMonoBehaviour
{
    [SerializeField] protected BulletDamageSender damageSender;
    public BulletDamageSender BulletDamageSender => damageSender;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadDamageSender();
    }
    protected virtual void LoadDamageSender()
    {
        if (this.damageSender != null) return;
        this.damageSender = GetComponentInChildren<BulletDamageSender>();
        Debug.LogWarning(transform.name + ": LoadDamageSender", gameObject);
    }
}
