using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectShooterBase : MyMonoBehaviour
{
    [Header("ObjectShooter Base")]
    [SerializeField] protected Transform startPos;

    [SerializeField] protected UpdateShooter shooterLevel;
    public UpdateShooter ShooterLevel => shooterLevel;

    [SerializeField]protected List<WeaponSO> weapons;
    // [SerializeField] protected string damagingName;
    [SerializeField] protected WeaponSO currrenWeapon;
    public WeaponSO CurrentDamaging => currrenWeapon;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadStartPos();
        this.LoadShooterLevel();
        this.LoadWeaponSO();
    }
    protected virtual void LoadWeaponSO()
    {
        if (this.weapons.Count !=0) return;
        this.weapons = this.GetWeaponSO();
        this.currrenWeapon = this.weapons[0];
        Debug.LogWarning(transform.name + ": LoadDamagingSO", gameObject);
    }
    protected abstract List<WeaponSO> GetWeaponSO();
    protected abstract string GetWeaponName();

    protected virtual void LoadShooterLevel()
    {
        if (this.shooterLevel != null) return;
        this.shooterLevel = GetComponentInChildren<UpdateShooter>();
        Debug.LogWarning(transform.name + ": LoadShooterLevel", gameObject);
    }

    protected virtual void LoadStartPos()
    {
        if (this.startPos != null) return;
        this.startPos = transform.Find("StartPos");
        Debug.LogWarning(transform.name + ": LoadStartPos", gameObject);
    }

}
