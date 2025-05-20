using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBulletMoving : ObjMoveForward
{
    protected override void GetDir()
    {
        Vector3 playerPos = PlayerCtrl.Instance.transform.position;
        this.direction = playerPos - transform.position;
        this.direction.Normalize();
    }
}
