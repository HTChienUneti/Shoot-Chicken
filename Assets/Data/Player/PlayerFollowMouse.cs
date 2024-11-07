using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollowMouse : ObjFollowTarget,IUsingMousePos
{
    [SerializeField] protected Vector3 mousePos;
    [SerializeField] protected bool isFirstEnable = true;
    protected override void OnEnable()
    {
        if (isFirstEnable) return;
        InputManager.Instance.AddMousePosListener(this);
    }
    protected override void Start()
    {
        base.Start();
        InputManager.Instance.AddMousePosListener(this);
        this.isFirstEnable = false;
    }
    protected virtual void OnDisable()
    {
        InputManager.Instance.RemoveMousePosListener(this);
    }
    protected override void ResetValue()
    {
        base.ResetValue();
        this.boundX = 8;
        this.boundY = 4;
    }
    protected override void FixedUpdate()
    {
        this.GetTargetPos();
        base.FixedUpdate();
    }

    public void OnMouseMove(Vector3 mousePos)
    {
        this.mousePos = mousePos;
    }

    protected override Vector3 GetTargetPos()
    {
        return this.mousePos;
    }
}
