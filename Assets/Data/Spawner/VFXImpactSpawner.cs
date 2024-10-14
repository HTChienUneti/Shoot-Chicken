//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class VFXImpactSpawner : Spawner
//{
//    [Header("VFX Dead Spawner")]
//    private static VFXImpactSpawner _instance;
//    public static VFXImpactSpawner Instance => _instance;
//    static public string impact_1 = "Impact_1";
//    protected override void Awake()
//    {
//        base.Awake();
//        this.LoadSingleton();
//    }
    
//    protected virtual void LoadSingleton()
//    {
//        if (VFXImpactSpawner._instance != null)
//        {
//            Debug.LogError("There are have more than 1 VFXImpactSpawner");
//            return;
//        }
//        VFXImpactSpawner._instance = this;
//    }
//}
