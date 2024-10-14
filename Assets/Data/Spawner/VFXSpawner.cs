using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXSpawner : Spawner
{
    [Header("VFX Dead Spawner")]
    private static VFXSpawner _instance;
    public static VFXSpawner Instance => _instance;
    static public string boom_1 = "Boom_1";
    static public string impact_1 = "Impact_1";
    protected override void Awake()
    {
        base.Awake();
        this.LoadSingleton();
    }
    
    protected virtual void LoadSingleton()
    {
        if (VFXSpawner._instance != null)
        {
            Debug.LogError("There are have more than 1 VFXDeadSpawner");
            return;
        }
        VFXSpawner._instance = this;
    }
}
