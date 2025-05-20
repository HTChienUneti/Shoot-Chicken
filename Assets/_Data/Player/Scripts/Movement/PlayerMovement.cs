using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : ObjParentMovement
{
    protected override void ResetValue()
    {
        base.ResetValue();
        this.boundX = 8;
        this.boundY = 4;
    }
}
