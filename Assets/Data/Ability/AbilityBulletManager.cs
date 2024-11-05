using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class AbilityBulletManager : MyMonoBehaviour
{
    static private AbilityBulletManager _instance;
    static public AbilityBulletManager Instance => _instance;
    [SerializeField] private float timeRemaining = 0f;
    [SerializeField] private float timeUse = 0f;  
    //[SerializeField] private float countdown = 0f;
    //[SerializeField] private float timeDelay = 0f;
    private List<IUsingBulletAbility> listeners = new List<IUsingBulletAbility>();
    protected override void Awake()
    {
        base.Awake();
        this.LoadSingleton();
    }

    public  void SetUsing(float time, float timeUse)
    {
        this.timeRemaining = time;
        this.timeUse = timeUse;
        this.OnUsing();
    }
    //public  void SetCountdown(float countdown,float timeDelay)
    //{
    //    this.countdown = countdown;
    //    this.timeDelay = timeDelay;
    //    this.Countdown();
    //}
    public  void AddListener(IUsingBulletAbility listener)
    {
        this.listeners.Add(listener);
    }
    public void RemoveListener(IUsingBulletAbility listener)
    {
        this.listeners.Remove(listener);
    }
    //private  void Countdown()
    //{
    //    foreach(IUsingBulletAbility listener in this.listeners)
    //    {
    //       // listener.Countdown(this.countdown,this.timeDelay);
    //    }
    //}
    private  void OnUsing()
    {
        foreach (IUsingBulletAbility listener in this.listeners)
        {
            listener.Using(this.timeRemaining,this.timeUse);
        }
    }
    private void LoadSingleton()
    {
        if (AbilityBulletManager._instance != null)
        {
            Debug.LogError("There are already have a ShooterAbilities");
            return;
        }
        AbilityBulletManager._instance = this;
    }
}
