using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverUI : MySingleton<GameOverUI>,IGameLoseState
{
    protected override void Start()
    {
        this.Hide();
    }
    protected virtual void Hide()
    {
        gameObject.SetActive(false);
    }
    protected virtual void Show()
    {
        gameObject.SetActive(true);
    }

    public void EnterState()
    {
        this.Show();
    }

    public void ExcuseState()
    {
        throw new System.NotImplementedException();
    }

    public void ExitState()
    {
        this.Hide();
    }
}
