using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Diagnostics;

public abstract class PowerAbilityByTime : BulletAbilityByTime
{
    [Header("Power Ability")]
    [SerializeField] protected int powwer =1;
    [SerializeField] protected int currentPower ;
    [SerializeField]static private bool isUsing = false;
    [SerializeField] protected ItemPower itemPower;

    public override void OnKeyDown()
    {
        if (PowerAbilityByTime.isUsing) return;
        base.OnKeyDown();
    }
    protected override void OnStartUse()
    {
        PowerAbilityByTime.isUsing = true;
        this.currentPower = PlayerCtrl.Instance.Shooter.ShooterLevel.CurrentLevel;
        base.OnStartUse();
        
    }
    protected override void OnUsing()
    {
        AbilityBulletManager.Instance.SetUsing(this.timeRemaining, this.timeUse);
    }
    protected override void OnUsed()
    {
        PowerAbilityByTime.isUsing = false;
        PlayerCtrl.Instance.Shooter.ShooterLevel.CurrentLevel =this.currentPower;
    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadItemPower();
    }
    protected virtual void LoadItemPower()
    {
        if (this.itemPower != null) return;
        string path = "SO/ItemPower/" + transform.name;
        this.itemPower = Resources.Load<ItemPower>(path);
        Debug.LogWarning(transform.name + " LoadItemPower", gameObject);
    }
}
