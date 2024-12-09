using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverUI : GameUI
{
    protected override void Start()
    {
        GameOverState.Instance.OnEnterState += GameOverState_OnEnterState;
        GameOverState.Instance.OnExitState += GameOverState_OnExitState;
       base.Start();    
    }

    private void GameOverState_OnEnterState(object sender, System.EventArgs e)
    {
        this.Show();
    }
    private void GameOverState_OnExitState(object sender, System.EventArgs e)
    {
        this.Hide();
    }
}
