using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverState : MySingleton<GameOverState>, IGameLoseState
{
    public void EnterState()
    {
        Debug.Log("Enter GameOverState");
    }

    public void ExcuseState()
    {
        
    }

    public void ExitState()
    {
        Debug.Log("Exit GameOverState");

    }
}
