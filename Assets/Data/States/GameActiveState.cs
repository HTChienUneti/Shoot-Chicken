using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameActiveState : MySingleton<GameActiveState>, IGameActiveState
{
    private List<IGameActiveState> gameActives = new List<IGameActiveState>();
    public void Add(IGameActiveState gameActive)
    {
        this.gameActives.Add(gameActive);
    }
    public void EnterState()
    {
        Debug.Log("GameActive enter");
        foreach(IGameActiveState gameActiveState in this.gameActives)
        {
            gameActiveState.EnterState();
        }
    }   

    public void ExcuseState()
    {
        throw new System.NotImplementedException();
    }

    public void ExitState()
    {
        Debug.Log("Gameactive exit");
        foreach (IGameActiveState gameActiveState in this.gameActives)
        {
            gameActiveState.ExitState();
        }
    }
}
