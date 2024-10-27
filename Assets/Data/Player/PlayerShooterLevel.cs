using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class PlayerShooterLevel : ShooterLevel
{
    static private PlayerShooterLevel _instance;
    static public PlayerShooterLevel Instance=>_instance;
  
    protected override void Awake()
    {
        base.Awake();
        this.LoadSingleton();
    }
    protected virtual void LoadSingleton()
    {
        if (PlayerShooterLevel._instance != null)
        {
            Debug.LogError("There are already have a PlayerShooterLevel", gameObject);
            return;
        }
        PlayerShooterLevel._instance = this;
    }
}
