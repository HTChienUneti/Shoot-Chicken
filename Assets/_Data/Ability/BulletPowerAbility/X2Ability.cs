using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Diagnostics;

public class X2Ability : PowerAbilityByTime
{
    protected override void ResetValue()
    {
        base.ResetValue();
        this.keyCode = KeyCode.R;
    }   
    protected override void OnStartUse()
    {
        base.OnStartUse();
        //PlayerCtrl.Instance.Shooter.ShooterLevel.Upgrade(ItemTypePowerup.Time, 2);
    }
}
