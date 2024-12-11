using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveUp : ObjMoveForward
{
    protected override void OnEnable()
    {
        base.OnEnable();
        this.isMoving = true;
    }
    protected override void ResetValue()
    {
        base.ResetValue();
        this.moveSpeed = 20f;
        this.direction = Vector3.up;
        this.boundY = 20;
        this.boundX = 20;
    }
    protected override void GetDir()
    {
        this.direction = transform.parent.up;
    }
}
