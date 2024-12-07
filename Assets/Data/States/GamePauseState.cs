using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePauseState : MySingleton<GamePauseState>, IGamePauseState
{
    protected List<IGamePauseState> gamePauses = new List<IGamePauseState>();

    public void AddListenter(IGamePauseState gamePauseState)
    {
        this.gamePauses.Add(gamePauseState);
    }
    public void EnterState()
    {
        Debug.Log("Enter GamePauseState");
        foreach(IGamePauseState gamePause in this.gamePauses)
        {
            gamePause.EnterState(); 
        }
    }

    public void ExcuseState()
    {
        
    }

    public void ExitState()
    {
        Debug.Log("Exit GamePauseState");
        foreach (IGamePauseState gamePause in this.gamePauses)
        {
            gamePause.ExitState();
        }
    }
}
