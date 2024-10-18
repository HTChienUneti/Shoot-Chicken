using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : ObjMovement
{
    protected override void ResetValue()
    {
        base.ResetValue();
        this.boundX = 100;
        this.boundY = 100;
    }
    protected override void FixedUpdate()
    {
        this.GetTargetPos();
        base.FixedUpdate();
    }
    protected override void GetTargetPos()
    {
        this.targetPos = transform.parent.position + Vector3.up;
    }
}
