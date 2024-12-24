using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameWinUI : GameUI
{ 
    protected override void Start()
    {
        base.Start();
        this.Hide();
        GameWinState.Instance.OnEnterState += GameWinState_OnEnterState;
    }

    private void GameWinState_OnEnterState(object sender, EventArgs e)
    {
        Invoke(nameof(this.Show),2f);
;    }
}
