using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggMovement : ObjMovement
{
    protected Vector3 dir;
    protected override void Start()
    {
        base.Start();
        this.GetTargetPos();
        this.GetDir();
    }
    protected virtual void GetDir()
    {
        this.dir = this.targetPos - transform.parent.position;
        dir.Normalize();
    }
    protected override void GetTargetPos()
    {
        this.targetPos = PlayerCtrl.Instance.transform.position;
    }
    protected override void Moving()
    {
        transform.parent.Translate(this.dir * this.moveSpeed * Time.fixedDeltaTime);
    }
}
