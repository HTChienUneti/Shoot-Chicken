using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveByKey : ObjParentMovement,IUsingHoriVertiKey
{
    [SerializeField] protected bool isFirstEnable = true;
    protected override void ResetValue()
    {
        this.boundX = 8;
        this.boundY = 4;
        base.ResetValue();
    }
    protected override void OnEnable()
    {
        base.OnEnable();
        if (isFirstEnable) return;
        InputManager.Instance.AddHoriVertiListener(this);
    }
    protected override void Start()
    {
        base.Start();
        InputManager.Instance.AddHoriVertiListener(this);
        this.isFirstEnable = false;  
        gameObject.SetActive(false);
    }
    public void OnValueChanged(float horizontal, float vertical)
    {
        transform.parent.position += new Vector3(horizontal, vertical, 0) * this.moveSpeed * Time.deltaTime;
        this.Bound();

    }
    protected virtual void OnDisable()
    {
        InputManager.Instance.RemoveHoriVertiListener(this);
    }
}
