using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerImpact : ShootableObjAbstract
{

    protected virtual bool ImpactBullet(Collider collision)
    {
        if (collision.transform.parent.GetComponent<BulletCtrl>()) return true;
        return false;
    }
}
