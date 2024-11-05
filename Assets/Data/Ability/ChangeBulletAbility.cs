using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class ChangeBulletAbility :BulletAbility
{
    [Header("Bullet Ability")]
    [SerializeField]static private bool isUsing = false;
    [SerializeField] protected DamagingSO damagingSO;
    [SerializeField] protected DamagingSO currentDamaging;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadDamagingSO();

    }
    protected override void OnUse()
    {
        this.currentDamaging = PlayerCtrl.Instance.Shooter.GetDamaging();
        base.OnUse();
        
    }
    protected override IEnumerator UsingAbility()
    {
        PlayerCtrl.Instance.Shooter.SetDamaging(this.damagingSO);
        return base.UsingAbility();
    }
    protected override void Used()
    {
        base.Used();
        PlayerCtrl.Instance.Shooter.SetDamaging(currentDamaging);
    }
    protected override void SetCountdown()
    {
     
    }
    protected virtual void LoadDamagingSO()
    {
        if (this.damagingSO != null) return;
        string path = "SO/Damaging/" + transform.name;
        this.damagingSO = Resources.Load<DamagingSO>(path);
        Debug.LogWarning(transform.name + " LoadDamagingSO", gameObject);
    }
}
