using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggSpawner : Spawner
{
    [Header("EggSpawner")]
    private static EggSpawner _instance;
    public static EggSpawner Instance => _instance;
    static public string egg_1 = "Egg_1";
    protected override void Awake()
    {
        base.Awake();
        this.LoadSingleton();
    }
    
    protected virtual void LoadSingleton()
    {
        if (EggSpawner._instance != null)
        {
            Debug.LogError("There are have more than 1 EggSpawner");
            return;
        }
        EggSpawner._instance = this;
    }
}
