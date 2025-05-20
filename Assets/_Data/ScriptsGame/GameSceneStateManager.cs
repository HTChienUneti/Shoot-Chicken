using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneStateManager : MySingleton<GameSceneStateManager>
{
    public  EventHandler<OngameChangedStateArgs> OnGameChangedState;
    [SerializeField] protected GameState currentState;
    [SerializeField] protected GameState prevState;
    public GameState PrevState => prevState;

    protected override void Start()
    {
        base.Start();
    }
    public virtual void ChangeState(GameState state)
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
