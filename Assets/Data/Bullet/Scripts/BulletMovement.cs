using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : ObjFollowTarget
{
    protected override void ResetValue()
    {
        base.ResetValue();
        this.boundX = 100;
        this.boundY = 100;
    }
    protected override Vector3 GetTargetPos()
    {
        return transform.parent.position + Vector3.up;
    }
}
