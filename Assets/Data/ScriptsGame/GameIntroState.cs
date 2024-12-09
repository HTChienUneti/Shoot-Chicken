using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class GameIntroState : MySingleton<GameIntroState>, IIntroState
{

    public event EventHandler OnEnterState;
    public event EventHandler OnExitState;
    public void EnterState()
    {
        Debug.Log("Enter IntroGame state");

        BackgroundManager.Instance.SetSpeed(20);
        StartCoroutine(CountdownIntro());
        this.OnEnterState?.Invoke(this, EventArgs.Empty);
    }
    protected IEnumerator CountdownIntro()
    {
        yield return new WaitForSeconds(3f);
        GameManager.Instance.ActiveGame();
    }   

    public void ExitState()
    {
        Debug.Log("Exit IntroGame state");
        BackgroundManager.Instance.SetSpeed(5f);
        this.OnExitState?.Invoke(this, EventArgs.Empty);
    }
}
