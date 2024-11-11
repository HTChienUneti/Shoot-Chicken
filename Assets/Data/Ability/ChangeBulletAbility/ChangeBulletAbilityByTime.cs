using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class ChangeBulletAbilityByTime : AbilityWeapon
{

    [Header("Change Bullet Ability")]
    [SerializeField] static private bool isUsing = false;
    //-----------------Function--------------------//
 
    public override void OnKeyDown()
    {
        if (ChangeBulletAbilityByTime.isUsing) return;
        base.OnKeyDown();
    }
    protected override void OnStartUse()
    {
        ChangeBulletAbilityByTime.isUsing = true;
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
        ChangeBulletAbilityByTime.isUsing = false;
        PlayerCtrl.Instance.Shooter.SetDamaging("Bullet_Blue");
        base.OnUsed();
    }
    protected override List<Ingredient> GetIngredient()
    {
        return this.damagingSO.ingredients;
    }
}
