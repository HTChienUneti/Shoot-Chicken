using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletCtrl : BulletCtrl
{
    protected override string GetPathToLoadWeaponSO()
    {
        return "SO/Weapon/Enemy/" + transform.name;
    }
}
