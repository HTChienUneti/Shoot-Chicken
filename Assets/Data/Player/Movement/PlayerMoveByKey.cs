using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class PlayerMoveByKey : ObjParentMovement
{
    [SerializeField] protected float horizontal;
    [SerializeField] protected float vertical;
    [SerializeField] protected bool isMoving;
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
        this.isMoving = true;   
    }
    protected override void Moving()
    {
        if (!this.isMoving) return;
        Vector3 input = new Vector3(this.horizontal, this.vertical, 0);
        input.Normalize();
        transform.parent.Translate(input * this.moveSpeed * Time.deltaTime);
        this.isMoving = false;
        base.Moving();
    }

}
