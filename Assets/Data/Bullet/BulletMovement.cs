using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : PlayerMovement
{
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
