using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjMovement : MyMonoBehaviour
{
    [SerializeField] protected float moveSpeed = 5f;
    [SerializeField] protected Vector3 targetPos;
    [SerializeField] protected float boundX = 100;
    [SerializeField] protected float boundY = 100f;
    [SerializeField] protected float distanceLimit = 0f;
    protected virtual void FixedUpdate()
    {
        this.GetTargetPos();
        this.Moving();
    }
    
    protected virtual void Moving()
    {
        if(transform.parent ==  null)
        {
            Debug.LogWarning(transform.name + ": have no a parent", gameObject);
        }
        if (Vector3.Distance(transform.parent.position, targetPos) <= distanceLimit) return;
        Vector3 lerp = Vector3.Lerp(transform.parent.position, this.targetPos, this.moveSpeed * Time.fixedDeltaTime);
        transform.parent.position = lerp;
        this.Bound();
    }
    protected virtual void Bound()
    {
        if (transform.parent.position.x < -this.boundX) transform.parent.position = new Vector3(-this.boundX, transform.parent.position.y, transform.parent.position.z);
        if (transform.parent.position.x > this.boundX) transform.parent.position = new Vector3(this.boundX, transform.parent.position.y, transform.parent.position.z);
        if (transform.parent.position.y < -this.boundY) transform.parent.position = new Vector3(transform.position.x, -boundY, transform.parent.position.z);
        if (transform.parent.position.y > this.boundY) transform.parent.position = new Vector3(transform.position.x, boundY, transform.parent.position.z);
    }
    protected abstract void GetTargetPos();
}
