using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterAbilitiesAbtract : MyMonoBehaviour
{
    [Header("Shooter Abilities Abstact")]
    [SerializeField] protected AbilityBulletManager shooterAbilities;
    public AbilityBulletManager ShooterAbilities =>shooterAbilities;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadShooterAbilities();
    }
    protected virtual void LoadShooterAbilities()
    {
        if (this.shooterAbilities != null) return;
        this.shooterAbilities = transform.parent.GetComponent<AbilityBulletManager>();
        Debug.LogWarning(transform.name + ": LoadShooterAbilities", gameObject);
    }

}
