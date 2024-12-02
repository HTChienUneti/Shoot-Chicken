using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameActiveState : MySingleton<GameActiveState>, IGameActiveState
{
    public void EnterState()
    {
        Debug.Log("Gameactive enter");
    }

    public void ExcuseState()
    {
        throw new System.NotImplementedException();
    }

    public void ExitState()
    {
        Debug.Log("Gameactive exit");
    }
}
