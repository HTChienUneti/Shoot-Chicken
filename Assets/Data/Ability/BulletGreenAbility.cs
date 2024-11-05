using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletGreenAbility : ChangeBulletAbility,IUsingInputAlpha2
{
    static private BulletGreenAbility _instance;
    static public BulletGreenAbility Instance =>_instance;
    protected override void Awake()
    {
        base.Awake();
        this.LoadSingleton();
    }
    protected override void Start()
    {
        base.Start();
        InputManager.Instance.AddAlpha2Listener(this);
    }
    protected override void SetCountdown()
    {
        base.SetCountdown();
        foreach (IUsingBulletGreenAbility listener in this.listeners)
        {
            listener.Countdown(this.timeCountdown, this.timeDelay);
        }
    }
    protected override void SetUsing()
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

   
}