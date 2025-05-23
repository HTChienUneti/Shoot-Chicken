using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponCtrl : DamagingObjCtrl
{
     [SerializeField] protected WeaponSO weaponSO;  
    public WeaponSO WeaponSO => weaponSO;

    [SerializeField] protected SpriteRenderer model;
 
   
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadDamageSender();
        this.LoadWeaponSO();
        this.LoadModel();
    }
    protected virtual void LoadModel()
    {
        if (this.model != null) return;
        this.model = GetComponentInChildren<SpriteRenderer>();
        this.model.sprite = this.WeaponSO.itemProfile.sprite;   
        Debug.LogWarning(transform.name + ": LoadModel", gameObject);
    }
    //protected virtual void LoadDamageSender()
    //{
    //    if (this.damageSender != null) return;
    //    this.damageSender = GetComponentInChildren<DamageSender>();
    //    Debug.LogWarning(transform.name + " :LoadDamageSender", gameObject);
    //}

    protected virtual void LoadWeaponSO()
    {
        if (this.WeaponSO != null) return;

        string path = this.GetPathToLoadWeaponSO();
        this.weaponSO = Resources.Load<WeaponSO>(path); 
      
        Debug.LogWarning(transform.name + " :LoadWeaponSO", gameObject);
    }
    protected abstract string GetPathToLoadWeaponSO();
}
