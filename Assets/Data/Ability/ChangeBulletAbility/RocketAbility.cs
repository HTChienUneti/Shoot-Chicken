using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketAbility :SpecialAbility
{
    static private RocketAbility _instance;
    static public RocketAbility Instance => _instance;


    protected override void ResetValue()
    {
        base.ResetValue();
        this.keyCode = KeyCode.Alpha1;
    }
    protected override void Awake()
    {
        base.Awake();
        this.LoadSingleton();
    }
    protected override void Start()
    {
        base.Start();
        InputManager.Instance.AddKeyDownListener(KeyCode.Alpha1, this);
    }
    private void LoadSingleton()
    {
        if (RocketAbility._instance != null)
        {
            Debug.LogError("There are already have a BulletRedAbility");
            return;
        }
        RocketAbility._instance = this;
    }

    protected override void Countdowning()
    {
        base.Countdowning();
        foreach (IUsingBulletAbility listener in this.listeners)
        {
            listener.Countdown(this.timeCountdown, this.timeDelay);
        }
    }
 
}