using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameWarningState : GameState
{

    static private GameWarningState _instance;
    static public GameWarningState Instance => _instance;
    [SerializeField] private float timeWarning = 5f;

    protected override void Awake()
    {
        base.Awake();
        this.LoadSingleton();
    }
    public override void EnterState()
    {
        base.EnterState();
        StartCoroutine(CountdownState());
    }

    private IEnumerator CountdownState()
    {
        yield return new WaitForSeconds(this.timeWarning);
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
