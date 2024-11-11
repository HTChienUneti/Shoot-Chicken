using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Diagnostics;

public class X2Ability : PowerAbilityByTime
{
    protected override void OnStartUse()
    {
        base.OnStartUse();
        PlayerCtrl.Instance.Shooter.ShooterLevel.LevelUp(ItemTypePowerup.Time, 2);
    }

    protected override KeyCode GetKeyCode()
    {
        return KeyCode.R;
    }
}
