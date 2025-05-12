using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCtrl : WeaponCtrl
{
    public virtual void SetModel(Sprite sprite)
    {
        this.model.sprite = sprite;
    }

    protected override string GetPathToLoadWeaponSO()
    {
        return "SO/Weapon/Player/";
    }
}
