using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjMovement : MyMonoBehaviour
{
    [SerializeField] protected float moveSpeed = 5f;
    [SerializeField] protected Vector3 targetPos;
    protected virtual void FixedUpdate()
    {
        this.GetTargetPos();
        this.Moving();
    }
    
    protected virtual void Moving()
    {
        Vector3 lerp = Vector3.Lerp(transform.parent.position, this.targetPos, this.moveSpeed * Time.fixedDeltaTime);
        transform.parent.position = lerp;
    }
    protected abstract void GetTargetPos();
}
