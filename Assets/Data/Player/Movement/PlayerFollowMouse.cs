using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollowMouse : ObjFollowTarget
{
    protected override void ResetValue()
    {
        base.ResetValue();
        this.boundX = 8;
        this.boundY = 4;
    }
    public virtual void SetBoundY(float boundY)
    {
        this.boundY = boundY;   
    }
}
