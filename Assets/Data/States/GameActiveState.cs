using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameActiveState : MySingleton<GameActiveState>, IGameActiveState
{
    public event EventHandler OnEnterState;
    public event EventHandler OnExitState;
    public void EnterState()
    {
        Debug.Log("GameActive enter");
        this.OnEnterState?.Invoke(this, EventArgs.Empty);
    }   

    public void ExitState()
    {
        Debug.Log("Gameactive exit");
        this.OnExitState?.Invoke(this, EventArgs.Empty);
    }
}
