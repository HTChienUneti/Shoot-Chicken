using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjParentMovement :MyMonoBehaviour
{
    [SerializeField] protected float moveSpeed = 5f;
    [SerializeField] protected float boundX = 100;
    [SerializeField] protected float boundY = 100f;
    [SerializeField] protected bool isMoving = false;
    protected override void Start()
    {
        base.Start();
        this.isMoving = true; 
        GameSceneStateManager.Instance.OnGameChangedState += GameSceneStateManager_OnGameChangedState;
    }
    protected virtual void GameSceneStateManager_OnGameChangedState(object sender, OngameChangedStateArgs e)
    {

        if (e.state.Equals(GameActiveState.Instance) ||
            e.state.Equals(GameWinState.Instance) ||
            e.state.Equals(GameWarningState.Instance))
        {
            this.isMoving = true;
        }
        else
        {
            this.isMoving = false;
        }
    }
    public virtual void SetSpeed(float speed)
    {
        this.moveSpeed = speed;
    }
    public virtual void SetBoundY(float boundY)
    {
        this.boundY = boundY;
    }
    protected virtual void FixedUpdate()
    {
        if (!this.isMoving) return;
        this.Moving();  
    }
    protected virtual void Moving()
    {
        
        this.Bound();
    }
    protected virtual void Bound()
    {
        if (transform.parent.position.x < -this.boundX) transform.parent.position = new Vector3(-this.boundX, transform.parent.position.y, transform.parent.position.z);
        if (transform.parent.position.x > this.boundX) transform.parent.position = new Vector3(this.boundX, transform.parent.position.y, transform.parent.position.z);
        if (transform.parent.position.y < -this.boundY) transform.parent.position = new Vector3(transform.position.x, -boundY, transform.parent.position.z);
        if (transform.parent.position.y > this.boundY) transform.parent.position = new Vector3(transform.position.x, boundY, transform.parent.position.z);
    }
}
