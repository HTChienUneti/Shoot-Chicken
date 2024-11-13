using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Diagnostics;

public class Add1Ability : PowerAbilityByTime
{
    protected override void ResetValue()
    {
        base.ResetValue();
        this.keyCode = KeyCode.E;
    }
    protected override void OnStartUse()
    {
        base.OnStartUse();
        PlayerCtrl.Instance.Shooter.ShooterLevel.LevelUp(ItemTypePowerup.Plus, this.powwer);
    }
}
