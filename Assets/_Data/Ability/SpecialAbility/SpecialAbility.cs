using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
public abstract class SpecialAbility : AbilityWeapon
{
 
    protected override IEnumerator UsingAbility()
    {
        
        PlayerCtrl.Instance.Shooter.Shoot(this.damagingSO);
        base.OnUsing();
  //      StartCoroutine(this.Countdown());
        yield break;
    }

}