using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePauseState : GameState
{
    static private GamePauseState _instance;
    static public GamePauseState Instance => _instance;
    protected override void Awake()
    {
        base.Awake();
        this.LoadSingleton();
    }
    protected virtual void LoadSingleton()
    {
        if (_instance != null)
        {
            Debug.LogWarning("There are already have a GameOverState", gameObject);
            Destroy(gameObject);
            Debug.LogWarning("Deleted new GameOverState", gameObject);
            return;
        }
        _instance = this;
    }

}
