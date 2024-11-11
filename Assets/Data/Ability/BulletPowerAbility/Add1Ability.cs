using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Diagnostics;

public class Add1Ability : PowerAbilityByTime
{
    protected override void OnStartUse()
    {
        base.OnStartUse();
        PlayerCtrl.Instance.Shooter.ShooterLevel.LevelUp(ItemTypePowerup.Plus, this.powwer);
    }
    protected override KeyCode GetKeyCode()
    {
        return KeyCode.E;
    }
}
