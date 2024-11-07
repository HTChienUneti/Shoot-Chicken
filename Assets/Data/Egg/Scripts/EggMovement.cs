using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggMovement : ObjMoveForward
{
    protected override void OnEnable()
    {
        base.OnEnable();
        this.GetDir();
    }
    protected override void GetDir()
    {
        Vector3 playerPos = PlayerCtrl.Instance.transform.position;
        this.direction = playerPos - transform.position;
        this.direction .Normalize();    
    }
}
