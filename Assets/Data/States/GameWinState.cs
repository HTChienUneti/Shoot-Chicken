using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameWinState : MySingleton<GameWinState>, IGameWinState
{
    public  event EventHandler OnEnterState;
    public EventHandler<EventArgs> OnExitState;
    public void EnterState()
    {
        Debug.Log("Enter GameWinState");

        Invoke(nameof(this.TriggerEnterState), 0f);
    }
    protected virtual void TriggerEnterState()
    {
        OnEnterState?.Invoke(this, EventArgs.Empty);
    }

    public void ExitState()
    {
        Debug.Log("Exit GameWinState");
        OnExitState?.Invoke(this, EventArgs.Empty);
    }
}
