using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletGreenAbility : ChangeBulletAbilityByTime
{
    static private BulletGreenAbility _instance;
    static public BulletGreenAbility Instance =>_instance;
    protected override void Awake()
    {
        base.Awake();
        this.LoadSingleton();
    }

    protected override void Countdowning()
    {
        foreach (IUsingBulletGreenAbility listener in this.listeners)
        {
            listener.Countdown(this.timeCountdown, this.timeDelay);
        }
    }
    protected override void OnUsing()
    {
    
        foreach (IUsingBulletGreenAbility listener in this.listeners)
        {
            listener.Using(this.timeRemaining, this.timeUse);
        }
    }
    private void LoadSingleton()
    {
        if(BulletGreenAbility._instance !=null)
        {
            Debug.LogError("There are already have a BulletGreenAbility");
            return;
        }
        BulletGreenAbility._instance = this;
    }

    protected override KeyCode GetKeyCode()
    {
        return KeyCode.Alpha2;
    }
}