using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingGameUI :GameUI
{
    protected override void Start()
    {
        base.Start();
        GameSettingsState.Instance.OnEnterState += GameSettingState_OnEnterState;
        GameSettingsState.Instance.OnExitState += GameSettingState_OnExitState;
    }

    private void GameSettingState_OnEnterState(object sender, System.EventArgs e)
    {
        this.Show();
    }  
    private void GameSettingState_OnExitState(object sender, System.EventArgs e)
    {
        this.Hide();
    }
}
