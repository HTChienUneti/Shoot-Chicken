using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjParentFollowTarget : ObjParentMovement
{
    [SerializeField] protected float distanceLimit = 0f;
    [SerializeField] protected Vector3 targetPos;
    [SerializeField] protected bool haveTarget;
    public virtual void SetTargetPos(Vector3  targetPos)
    {
        this.targetPos = targetPos;
        this.haveTarget = true;
    }
    protected override void Moving()
    {
        if(transform.parent ==  null)
        {
            Debug.LogWarning(transform.name + ": have no a parent", gameObject);
        }
        if (!this.haveTarget) return;
        if (Vector3.Distance(transform.parent.position, this.GetTargetPos()) <= distanceLimit) return;
        Vector3 lerp = Vector3.Lerp(transform.parent.position, this.GetTargetPos(), this.moveSpeed * Time.fixedDeltaTime);
        transform.parent.position = lerp;
        base.Moving();
    }
    protected virtual Vector3 GetTargetPos()
    {
        return this.targetPos;  
    }
}
