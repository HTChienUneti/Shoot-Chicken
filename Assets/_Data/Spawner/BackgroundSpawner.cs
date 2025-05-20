using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSpawner : Spawner
{
    [Header("Background Spawner")]
    private static BackgroundSpawner _instance;
    public static BackgroundSpawner Instance => _instance;
    static public string background_1 = "Background_1";

    protected override void Awake()
    {
        base.Awake();
        this.LoadSingleton();
    }
    
    protected virtual void LoadSingleton()
    {
        if (BackgroundSpawner._instance != null)
        {
            Debug.LogError("There are have more than 1 BackgroundSpawner");
            return;
        }
        BackgroundSpawner._instance = this;
    }
    public override void Despawn(Transform obj)
    {
        base.Despawn(obj);

    }

}
