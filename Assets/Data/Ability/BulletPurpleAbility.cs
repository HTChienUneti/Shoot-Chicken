using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletPurpleAbility : ChangeBulletAbility,IUsingInputAlpha3
{
    static private BulletPurpleAbility _instance;
    static public BulletPurpleAbility Instance =>_instance;


    protected override void Awake()
    {
        base.Awake();
        this.LoadSingleton();
    }
    protected override void Start()
    {
        base.Start();
        InputManager.Instance.AddAlpha3Listener(this);
    }
    protected override void SetCountdown()
    {
        base.SetCountdown();
        foreach (IUsingBulletPurpleAbility listener in this.listeners)
        {
            listener.Countdown(this.timeCountdown, this.timeDelay);
        }
    }
    protected override void SetUsing()
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