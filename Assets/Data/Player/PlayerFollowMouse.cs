using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollowMouse : ObjMovement
{
    protected override void ResetValue()
    {
        base.ResetValue();
        this.boundX = 8;
        this.boundY = 4;
    }
    protected override void FixedUpdate()
    {
        this.GetTargetPos();
        base.FixedUpdate();
    }
   
    protected override void GetTargetPos()
    {
        this.targetPos = InputManager.Instance.MouseWorldPos;
    }
}
