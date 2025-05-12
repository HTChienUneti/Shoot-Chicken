using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameState : MyMonoBehaviour
{
    public event EventHandler OnEnterState;
    public event EventHandler OnExitState;

    public virtual void EnterState()
    {
        Debug.Log(this.name+" enter");
        this.OnEnterState?.Invoke(this, EventArgs.Empty);
    }

    public virtual void ExitState()
    {
        Debug.Log(this.name +" exit");
        this.OnExitState?.Invoke(this, EventArgs.Empty);
    }
}
