using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenMovement : ObjMovement
{
    [Header("Chicken Follow Target")]
    [SerializeField] protected LayerMask layer;
    [SerializeField] protected bool isMovingDown = true;
    public bool IsMovingDown => isMovingDown;
    [SerializeField] protected CircleCollider2D circleCollider;
    protected override void ResetValue()
    {
        base.ResetValue();
        this.boundY = 2f;
    }
    protected override void GetTargetPos()  
    {
        this.targetPos = PlayerCtrl.Instance.transform.position;
    }
    protected override void FixedUpdate()
    {
       // this.MoveDown();
        base.FixedUpdate();
    }
    protected virtual void MoveDown()
    {
        if (!this.isMovingDown) return;
        Vector3 lerp = Vector3.Lerp(transform.parent.position, this.targetPos, this.moveSpeed * Time.fixedDeltaTime);
        transform.parent.position = lerp;
        if (transform.parent.position.y <= boundY) this.isMovingDown = false;
    }
    protected override void Moving()
    {
        if (transform.parent.position.y <= this.boundY)
        {
            this.isMovingDown = false;
            return;
        }
        Vector3 lerp = Vector3.Lerp(transform.parent.position, this.targetPos, this.moveSpeed * Time.fixedDeltaTime);
        if(lerp.y < this.boundY ) lerp.y = this.boundY;
        if(lerp.x < -this.boundX ) lerp.x = -this.boundX;
        if(lerp.x > this.boundX ) lerp.x = this.boundX;
       transform.parent.position = lerp;
         // if(!CheckBeside()) transform.parent.position = lerp;

    }
    protected virtual bool CheckBeside()
    {
       // Debug.Log(transform.parent.position);
        RaycastHit2D hitLeft = Physics2D.CircleCast(transform.parent.position,0.5f,Vector2.left,100f,layer);
        RaycastHit2D hitRigth = Physics2D.CircleCast(transform.parent.position,0.5f,Vector2.right,100f,layer);
        if ((hitLeft || hitRigth) && hitLeft.collider != this.circleCollider && hitRigth.collider != this.circleCollider)
        {
            return true;
        }
        return false;
      
    }
}
