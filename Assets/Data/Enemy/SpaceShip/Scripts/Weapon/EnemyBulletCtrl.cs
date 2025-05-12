using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletCtrl : WeaponCtrl
{
    protected override string GetPathToLoadWeaponSO()
    {
        return "SO/Weapon/Enemy/";
    }
}
    