using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneStateManager : MySingleton<GameSceneStateManager>
{
    [SerializeField] protected IGameSceneState currentState;
    [SerializeField] protected IGameSceneState prevState;
    public IGameSceneState PrevState => prevState;
    protected override void Start()
    {
        base.Start();
        this.SetState(IntroGame.Instance);
    }
    public virtual void SetState(IGameSceneState state)
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
        
    }
}
