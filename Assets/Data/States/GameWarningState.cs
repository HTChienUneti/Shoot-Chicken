using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameWarningState : GameState
{

    static private GameWarningState _instance;
    static public GameWarningState Instance => _instance;
    [SerializeField] private bool isEnter = false;
    [SerializeField] private float timeMax = 5f;
    [SerializeField] private float timer = 0f;

    protected override void Awake()
    {
        base.Awake();
        this.LoadSingleton();
    }
    public override void EnterState()
    {
        base.EnterState();
        this.isEnter = true;
    }
    public override void ExitState()
    {
        base.ExitState();
        this.isEnter = false;
    }
    private void FixedUpdate()
    {
        this.CountdownState();
    }
    private void CountdownState()
    {
        if (!this.isEnter) return;
        this.timer += Time.fixedDeltaTime;
        if (this.timer < this.timeMax) return;
        this.timer = 0f;
        GameManager.Instance.PlayGame();
    }
    protected virtual void LoadSingleton()
    {
        if (_instance != null)
        {
            Debug.LogWarning("There are already have a GameWarningState", gameObject);
            Destroy(gameObject);
            Debug.LogWarning("Deleted new GameWarningState", gameObject);
            return;
        }
        _instance = this;
    }
}
