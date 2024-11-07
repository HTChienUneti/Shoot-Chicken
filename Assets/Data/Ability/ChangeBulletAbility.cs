using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class ChangeBulletAbility :BulletAbility
{
    [Header("Change Bullet Ability")]
    [SerializeField]static private bool isUsing = false;
    [SerializeField] protected DamagingSO damagingSO;
    [SerializeField] protected DamagingSO currentDamaging;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadDamagingSO();

    }
    public override void OnKeyDown()
    {
        if (ChangeBulletAbility.isUsing) return;
        base.OnKeyDown();
    }
    protected override void OnStartUse()
    {
        ChangeBulletAbility.isUsing = true;
        this.currentDamaging = PlayerCtrl.Instance.Shooter.GetDamaging();
        base.OnStartUse();
        
    }
    protected override IEnumerator UsingAbility()
    {
        PlayerCtrl.Instance.Shooter.SetDamaging(this.damagingSO);
        return base.UsingAbility();
    }
    protected override void OnUsed()
    {
        ChangeBulletAbility.isUsing = false;
        PlayerCtrl.Instance.Shooter.SetDamaging("Bullet_Blue");
    }
    protected virtual void LoadDamagingSO()
    {
        if (this.damagingSO != null) return;
        string path = "SO/Damaging/" + transform.name;
        this.damagingSO = Resources.Load<DamagingSO>(path);
        Debug.LogWarning(transform.name + " LoadDamagingSO", gameObject);
    }
}
