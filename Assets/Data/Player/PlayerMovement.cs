using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : ObjMovement
{
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
