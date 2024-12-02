using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneStateManager : MySingleton<GameSceneStateManager>
{
    [SerializeField] protected IGameSceneState currentState;
    protected override void Start()
    {
        base.Start();
        currentState = GameActiveState.Instance;
        this.SetState(currentState);
    }
    public virtual void SetState(IGameSceneState state)
    {
        if (this.currentState == state) return;
        this.currentState.ExitState();
        this.currentState = state;
        this.currentState.EnterState(); 
        
    }
}
