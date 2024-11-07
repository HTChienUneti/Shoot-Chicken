using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Diagnostics;

public abstract class PowerAbility : BulletAbility
{
    [Header("Power Ability")]
    [SerializeField] protected int powwer =1;
    [SerializeField] protected int currentPower ;
    [SerializeField]static private bool isUsing = false;

    public override void OnKeyDown()
    {
        if (PowerAbility.isUsing) return;
        base.OnKeyDown();
    }
    protected override void OnStartUse()
    {
        PowerAbility.isUsing = true;
    //   BulletAbility.anotherUsed= true;
        this.currentPower = PlayerCtrl.Instance.Shooter.ShooterLevel.CurrentLevel;
        base.OnStartUse();
        
    }
    protected override void OnUsing()
    {
        AbilityBulletManager.Instance.SetUsing(this.timeRemaining, this.timeUse);
    }
    protected override void OnUsed()
    {
        PowerAbility.isUsing = false;
      //  if (this.Check()) return;
        PlayerCtrl.Instance.Shooter.ShooterLevel.CurrentLevel =this.currentPower;
    }
  
  
}
