using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class GameIntroState : GameState
{
    static private GameIntroState _instance;
    static public GameIntroState Instance => _instance;
    [SerializeField]private  float timeIntro = 7;
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
    public override void ExitState()
    {
        base.ExitState();
    }
    private IEnumerator CountdownState()
    {
        yield return new WaitForSeconds(this.timeIntro);
        GameManager.Instance.WarningGame();
    }
    protected virtual void LoadSingleton()
    {
        if (_instance != null)
        {
            Debug.LogWarning("There are already have a GameIntroState", gameObject);
            Destroy(gameObject);
            Debug.LogWarning("Deleted new GameIntroState", gameObject);
            return;
        }
        _instance = this;
    }
}
