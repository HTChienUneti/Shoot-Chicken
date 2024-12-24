using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayingGameState : GameState, IGameActiveState
{
    static private PlayingGameState _instance;
    static public PlayingGameState Instance => _instance;
    protected override void Awake()
    {
        base.Awake();
        this.LoadSingleton();
    }
    protected virtual void LoadSingleton()
    {
        if (_instance != null)
        {
            Debug.LogWarning("There are already have a GameActiveState", gameObject);
            Destroy(gameObject);
            Debug.LogWarning("Deleted new GameActiveState", gameObject);
            return;
        }
        _instance = this;
    }
}
