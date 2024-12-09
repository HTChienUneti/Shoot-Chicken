using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMovement : ObjParentFollowTarget
{


    protected override void ResetValue()
    {
        base.ResetValue();
        this.haveTarget = true;
    }
    protected override Vector3 GetTargetPos()
    {
        return transform.position + new Vector3(0, -1, 0);
    }
}
