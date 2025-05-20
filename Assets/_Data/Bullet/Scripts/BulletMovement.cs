using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : ObjMoveForward
{
    protected override void ResetValue()
    {
        base.ResetValue();
        this.boundX = 100;
        this.boundY = 100;
    }

    protected override void GetDir()
    {
        this.direction = Vector3.up;
    }
}
