using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettingsState : GameState
{
    static private GameSettingsState _instance;
    static public GameSettingsState Instance => _instance;
    protected override void Awake()
    {
        base.Awake();
        this.LoadSingleton();
    }
    protected virtual void LoadSingleton()
    {
        if (_instance != null)
        {
            Debug.LogWarning("There are already have a GameSettingsState", gameObject);
            Destroy(gameObject);
            Debug.LogWarning("Deleted new GameSettingsState", gameObject);
            return;
        }
        _instance = this;
    }
}
