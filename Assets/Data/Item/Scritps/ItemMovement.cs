using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMovement : ObjFollowTarget
{
    protected override Vector3 GetTargetPos()
    {
        return transform.position + new Vector3(0, -1, 0);
    }
}
