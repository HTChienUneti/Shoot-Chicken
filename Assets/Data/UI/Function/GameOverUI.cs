using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverUI : UIAbstract,IOverGame
{
    protected override void Start()
    {
        base.Start();
        GameManager.Instance.AddGameOverListener(this);
    }
    public void OnGameOver()
    {
        this.Show();
    }
}
