using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletCtrl : BulletCtrl
{
    protected override string GetPathToLoadWeaponSO()
    {
        return "SO/Weapon/Player/"+transform.name;
    }
}
