using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenMovement : ObjMovement
{

    protected override void ResetValue()
    { 
        this.distanceLimit = 0f;
        this.boundY = 10f;
        this.boundX = 4f;
        this.moveSpeed = .5f;
    }
    protected override void GetTargetPos()  
    {
        this.targetPos = PlayerCtrl.Instance.transform.position;
    }
    
    protected override void Moving()
    {
        
        base.Moving();
    }
    
}
