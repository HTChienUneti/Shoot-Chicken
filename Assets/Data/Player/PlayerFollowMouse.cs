using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollowMouse : ObjFollowTarget
{

    [SerializeField] protected bool isFirstEnable = true;
    protected override void ResetValue()
    {
        base.ResetValue();
        this.boundX = 8;
        this.boundY = 4;
    }
}
