using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePauseUI : UIAbstract, IPauseGame, IActiveGame
{
    protected override void Start()
    {
       base.Start();
        GameManager.Instance.AddPauseListener(this);
        GameManager.Instance.AddActiveListener(this);
    }
    public void OnPauseGame()
    {
        this.Show();
    }
    public void OnActiveGame()
    {
        this.Hide();
    }
}
