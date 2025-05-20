using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIStateManager : MySingleton<UIStateManager>
{
     protected IUIState currentSate;
    protected override void Start()
    {
        base.Start();
        this.currentSate = HomeUIState.Instance;
    }
    public void SetState(IUIState state)
    {
        if(this.currentSate == state) return;
        this.currentSate.ExitState();
        this.currentSate = state;
        Debug.Log(currentSate);
        this.currentSate.EnterState();
    }
}
