using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletPurpleAbility : ChangeBulletAbilityByTime
{
    static private BulletPurpleAbility _instance;
    static public BulletPurpleAbility Instance =>_instance;


    protected override void Awake()
    {
        base.Awake();
        this.LoadSingleton();
    }
    protected override void ResetValue()
    {
        base.ResetValue();
        this.keyCode  = KeyCode.Alpha3; ;
    }

    protected override void Countdowning()
    {
        //se.SetCountdown();
        foreach (IUsingBulletPurpleAbility listener in this.listeners)
        {
            listener.Countdown(this.timeCountdown, this.timeDelay);
        }
    }
    protected override void OnUsing()
    {
        foreach (IUsingBulletPurpleAbility listener in this.listeners)
        {
            listener.Using(this.timeRemaining, this.timeUse);
        }
    }
    //public virtual void AddListener(IUsingBulletPurpleAbility listener)
    //{
    //    this.listeners.Add(listener);
    //}
    private void LoadSingleton()
    {
        if(BulletPurpleAbility._instance !=null)
        {
            Debug.LogError("There are already have a BulletPurpleAbility");
            return;
        }
        BulletPurpleAbility._instance = this;
    }
}