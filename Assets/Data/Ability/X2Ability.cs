using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Diagnostics;

public class X2Ability : PowerAbility,IUsingInputKeyR
{
    protected override void Start()
    {
        base.Start();
        InputManager.Instance.AddKeyRListener(this);
    }
    protected override void OnStartUse()
    {
        base.OnStartUse();
        PlayerCtrl.Instance.Shooter.ShooterLevel.LevelUp(ItemTypePowerup.Time, 2);
      
    }
  
}
