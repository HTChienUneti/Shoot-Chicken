using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollowMouse : ObjParentFollowTarget,IUsingMousePos
{

    protected override void Start()
    {
        base.Start();
        this.isMoving = false;
        InputManager.Instance.AddMousePosListener(this);
    }
    public void OnMouseMove(Vector3 mousePos)
    {
        this.haveTarget = true;
        this.targetPos = mousePos;
    }

    protected override void ResetValue()
    {
        base.ResetValue();
        this.boundX = 8;
        this.boundY = 4;
    }
    
}
