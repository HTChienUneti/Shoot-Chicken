using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletRedAbility : ChangeBulletAbilityByTime
{
    static private BulletRedAbility _instance;
    static public BulletRedAbility Instance => _instance;

    protected override void Awake()
    {
        base.Awake();
        this.LoadSingleton();
    }
    protected override void Countdowning()
    {
      //base.SetCountdown();
        foreach (IUsingBulletRedAbility listener in this.listeners)
        {
            listener.Countdown(this.timeCountdown, this.timeDelay);
        }
    }
    protected override void OnUsing()
    {
        foreach (IUsingBulletRedAbility listener in this.listeners)
        {
            listener.Using(this.timeRemaining, this.timeUse);
        }
    }
    private void LoadSingleton()
    {
        if (BulletRedAbility._instance != null)
        {
            Debug.LogError("There are already have a BulletRedAbility");
            return;
        }
        BulletRedAbility._instance = this;
    }

    protected override KeyCode GetKeyCode()
    {
        return KeyCode.Alpha4;
    }
}