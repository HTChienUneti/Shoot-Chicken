using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGameSceneState
{
    public void EnterState();

    public void ExcuseState();
    public void ExitState();
}
