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
 
        GameWarningState.Instance.OnEnterState += GameWarningState_OnEnterState;
      // GameIntroState.Instance.OnEnterState += GameIntroState_OnEnterState;
    }

    private void GameWarningState_OnEnterState(object sender, System.EventArgs e)
    {
        this.speed = 5f;
    }

    private void GameIntroState_OnEnterState(object sender, System.EventArgs e)
    { 
        this.speed = 30f;
    }
    private void FixedUpdate()
    {
        transform.Translate(Vector3.down * this.speed * Time.fixedDeltaTime);
        if(transform.position.y <= this.boundY)
        {
            transform.position = this.defaultPos;
        }
    }
}
