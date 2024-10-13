using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggCtrl : MyMonoBehaviour
{
    [SerializeField] protected EggDamageSender damageSender;
    public EggDamageSender EggDamageSender => damageSender;
    [SerializeField] protected ChickenShooter shooter;
    public ChickenShooter Shooter => shooter;
    public virtual void SetShooter(ChickenShooter shooter)
    {
        this.shooter = shooter;
    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadDamageSender();
    }
    protected virtual void LoadDamageSender()
    {
        if (this.damageSender != null) return;
        this.damageSender = GetComponentInChildren<EggDamageSender>();
        Debug.LogWarning(transform.name + ": LoadDamageSender", gameObject);
    }
}
