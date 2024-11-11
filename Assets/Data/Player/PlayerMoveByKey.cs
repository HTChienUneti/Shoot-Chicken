using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveByKey : ObjParentMovement
{
    [SerializeField] protected float horizontal;
    [SerializeField] protected float vertical;
    protected override void ResetValue()
    {
        this.boundX = 8;
        this.boundY = 4;
        base.ResetValue();
    }
    protected override void Start()
    {
        gameObject.SetActive(false);
    }
    public void SetKeyValue(float horizontal, float vertical)
    {
        this.horizontal = horizontal;
        this.vertical = vertical;
    }
    protected override void Moving()
    {
        transform.parent.position += new Vector3(this.horizontal, this.vertical, 0) * this.moveSpeed * Time.deltaTime;
        base.Moving();
    }
}
