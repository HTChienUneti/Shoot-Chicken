using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameActiveObject : MyMonoBehaviour
{
    [SerializeField]protected bool isActive = false;
    protected override void Start()
    {
        base.Start();
        GameActiveState.Instance.OnEnterState += GameActiveState_OnEnterState;
        GameActiveState.Instance.OnExitState += GameActiveState_OnExitState;
    }

    private void GameActiveState_OnEnterState(object sender, System.EventArgs e)
    {
        this.isActive = true;
    }
    private void GameActiveState_OnExitState(object sender, System.EventArgs e)
    {
        this.isActive = false;
    }
    protected virtual void FixedUpdate()
    {
        if (!isActive) return;
    }
}
