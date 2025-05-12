using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameWinState : GameState
{
    static private GameWinState _instance;
    static public GameWinState Instance => _instance;
    protected override void Awake()
    {
        base.Awake();
        this.LoadSingleton();
    }
    protected virtual void LoadSingleton()
    {
        if (_instance != null)
        {
            Debug.LogWarning("There are already have a GameWinState", gameObject);
            Destroy(gameObject);
            Debug.LogWarning("Deleted new GameWinState", gameObject);
            return;
        }
        _instance = this;
    }
}
