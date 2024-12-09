using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameState : MyMonoBehaviour
{
    public event EventHandler OnEnterState;
    public event EventHandler OnExitState;

    public void EnterState()
    {
        Debug.Log(this.name+" enter");
        this.OnEnterState?.Invoke(this, EventArgs.Empty);
    }   

    public void ExitState()
    {
        Debug.Log("Gameactive exit");
        this.OnExitState?.Invoke(this, EventArgs.Empty);
    }
}
