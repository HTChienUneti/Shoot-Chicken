using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameWinState : MySingleton<GameWinState>, IGameWinState
{
    protected List<IGameWinState> gameWinStates = new List<IGameWinState>();
    [SerializeField] private bool isEntered = false;
    public virtual void AddListener(IGameWinState gameWinState)
    {
        this.gameWinStates.Add(gameWinState);
    }

    public void EnterState()
    {
        Debug.Log("Enter GameWinState");
        foreach(IGameWinState gameWin in this.gameWinStates)
        {
            gameWin.EnterState();
        }
        Invoke(nameof(SetEnter), 5f);
      
    }
    protected virtual void SetEnter()
    {
        this.isEntered = true;
    }
    private void FixedUpdate()
    {
        if (!this.isEntered) return;
        this.ExcuseState();
    }
    public void ExcuseState()
    {
        foreach (IGameWinState gameWin in this.gameWinStates)
        {
            gameWin.ExcuseState();
        }
        
    }

    public void ExitState()
    {
        Debug.Log("Exit GameWinState");
        foreach (IGameWinState gameWin in this.gameWinStates)
        {
            gameWin.ExitState();
        }
        this.isEntered = false;

    }
}
