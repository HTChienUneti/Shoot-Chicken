using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveUp : ObjMoveForward
{
    protected override void GetDir()
    {
        this.direction = transform.parent.up;
    }
}
