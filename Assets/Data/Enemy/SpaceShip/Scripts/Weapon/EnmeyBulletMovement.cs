using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnmeyBulletMovement : ObjMoveForward
{
    protected override void OnEnable()
    {
        base.OnEnable();
        this.GetDir();
    }
    protected override void GetDir()
    {
        this.direction = -transform.parent.up;
    
    }
}
