using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameState : MyMonoBehaviour
{
    [SerializeField] protected bool isEnter;
    [SerializeField] protected bool isExit;
    public event EventHandler OnEnterState;
    public event EventHandler OnExitState;

    public virtual void EnterState()
    {
        Debug.Log(this.name+" enter");
        this.isEnter = true;
        this.OnEnterState?.Invoke(this, EventArgs.Empty);
    }

    public virtual void ExitState()
    {
        this.isExit = true;
        this.isEnter = false;
        Debug.Log(this.name +" exit");
        this.OnExitState?.Invoke(this, EventArgs.Empty);
    }
}
