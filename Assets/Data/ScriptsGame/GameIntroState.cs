using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class GameIntroState : GameState
{
    static private GameIntroState _instance;
    static public GameIntroState Instance => _instance;
    private bool isEnter = false;
    [SerializeField]private  float timeMax = 10f;
    [SerializeField]  private float timer = 0f;

    protected override void Awake()
    {
        base.Awake();
        this.LoadSingleton();
    }
    public override void EnterState()
    {
        base.EnterState();
        this.isEnter = true;
        StartCoroutine(CountdownState());
    }
    public override void ExitState()
    {
        base.ExitState();
        this.isEnter = false;
    }
    private void FixedUpdate()
    {
        //this.CountdownState();
    }
    private IEnumerator CountdownState()
    {
        yield return new WaitForSeconds(this.timeMax);
        //if (!this.isEnter) return;
        //this.timer += Time.fixedDeltaTime;
        //if (this.timer < this.timeMax) return;
        //this.timer = 0f;
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
