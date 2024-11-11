using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class AbilityWeapon : BulletAbilityByTime
{

    [Header("Ability Weapon")]
    [SerializeField] protected DamagingSO damagingSO;
    [SerializeField] protected DamagingSO currentDamaging;
    //-----------------Function--------------------/
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadDamagingSO();
    }
    protected virtual void LoadDamagingSO()
    {
        if (this.damagingSO != null) return;
        string path = "SO/Damaging/" + transform.name;
        this.damagingSO = Resources.Load<DamagingSO>(path);
        Debug.LogWarning(transform.name + " LoadDamagingSO", gameObject);

    }
}
