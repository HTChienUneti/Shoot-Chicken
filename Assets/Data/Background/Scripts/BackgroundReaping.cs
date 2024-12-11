using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundReaping : MyMonoBehaviour
{
    [SerializeField] protected float boundY = -40;
    [SerializeField] protected float speed = 5f;
    [SerializeField] protected Vector3 defaultPos = new Vector3(0,15,0);
    [SerializeField] protected bool isMoving = true;
    protected override void Start()
    {
        base.Start();
        GameActiveState.Instance.OnEnterState += GameActiveState_OnEnterState;
        GameActiveState.Instance.OnExitState += GameActiveState_OnExitState;
        GameIntroState.Instance.OnEnterState += GameIntroState_OnEnterState;
        GameIntroState.Instance.OnExitState += GameIntroState_OnExitState;
        GameWarningState.Instance.OnEnterState += GameWarningState_OnEnterState;
        GameWarningState.Instance.OnExitState += GameWarningState_OnExitState;
    }

    private void GameIntroState_OnEnterState(object sender, System.EventArgs e)
    {
        this.isMoving = true;
        this.speed = 30f;
    }
    private void GameIntroState_OnExitState(object sender, System.EventArgs e)
    {
        this.isMoving = false;
    }
    private void GameActiveState_OnExitState(object sender, System.EventArgs e)
    {
        this.isMoving = false;
    }

    private void GameActiveState_OnEnterState(object sender, System.EventArgs e)
    {
        this.isMoving = true;
        this.speed = 5f;
    }
    private void GameWarningState_OnEnterState(object sender, System.EventArgs e)
    {
        this.isMoving = true;
        this.speed = 5;
    }
    private void GameWarningState_OnExitState(object sender, System.EventArgs e)
    {
        this.isMoving = false;
    }

    public virtual void SetSpeed(float speed)
    {
        this.speed = speed;
    }
    private void FixedUpdate()
    {
        if (!this.isMoving) return;
        transform.Translate(Vector3.down * this.speed * Time.fixedDeltaTime);
        if(transform.position.y <= this.boundY)
        {
            transform.position = this.defaultPos;
        }
    }
}
