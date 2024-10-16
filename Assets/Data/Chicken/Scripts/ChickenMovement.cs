using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenMovement : ObjMovement
{
    //[Header("Chicken Follow Target")]
   // [SerializeField] protected LayerMask layer;
   // [SerializeField] protected bool isMovingDown = true;
  //  public bool IsMovingDown => isMovingDown;
  //  [SerializeField] protected CircleCollider2D circleCollider;
    protected override void ResetValue()
    {
      //  this.isMovingDown = true;
        this.distanceLimit = 6f;
        this.boundY = 5f;
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
