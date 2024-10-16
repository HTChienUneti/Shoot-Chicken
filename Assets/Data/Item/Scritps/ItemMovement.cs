using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMovement : ObjMovement
{
    protected override void GetTargetPos()
    {
        this.targetPos = transform.position + new Vector3(0, -1, 0);
    }
}
