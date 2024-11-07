using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjMoveForward : ObjParentMovement
{
    [SerializeField] protected Vector3 direction = Vector3.down;
    protected override void Start()
    {
        base.Start();
        this.GetDir();
    }
    protected override void Moving()
    {
      //  Debug.DrawLine(transform.position, direction);
        transform.parent.Translate(this.direction * this.moveSpeed * Time.fixedDeltaTime);
        base.Moving();
    }
    protected abstract void GetDir();
}
