using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePauseUI : GameUI,IUsingKeyDown
{
    protected override void Start()
    {
        InputManager.Instance.AddKeyDownListener(KeyCode.Escape,this);
        GamePauseState.Instance.OnEnterState += GamePauseState_OnEnterState;
        GamePauseState.Instance.OnExitState += GamePauseState_OnExitState;
        base.Start();
    }

    private void GamePauseState_OnEnterState(object sender, System.EventArgs e)
    {
        this.Show();
    }    
    private void GamePauseState_OnExitState(object sender, System.EventArgs e)
    {
        this.Hide();
    }
    public void OnKeyDown()
    {
        this.isShowing =! this.isShowing;
        if(this.isShowing)
        {
            GameManager.Instance.PauseGame();
        }
        else
        {
            GameManager.Instance.BackPrevState();
        }
       
    }
}
