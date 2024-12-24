using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneStateManager : MySingleton<GameSceneStateManager>
{
    public  EventHandler<OngameChangedStateArgs> OnGameChangedState;
    [SerializeField] protected IGameSceneState currentState;
    [SerializeField] protected IGameSceneState prevState;
    public IGameSceneState PrevState => prevState;

    protected override void Start()
    {
        base.Start();
        this.ChangeState(GameIntroState.Instance);
    }
    public virtual void ChangeState(IGameSceneState state)
    {
        if (this.currentState == state) return;
        if(this.currentState != null)
        {
            this.prevState = currentState;
            Debug.Log("Prev: "+this.prevState);
            this.currentState.ExitState();
        }
        this.currentState = state;
        this.currentState.EnterState();
        this.OnGameChangedState?.Invoke(this, new OngameChangedStateArgs()
        {
            state = this.currentState
        }); 
        
    }
}
