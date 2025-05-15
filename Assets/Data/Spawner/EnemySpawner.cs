using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : Spawner
{
    [Header("EnemySpawner")]
    private static EnemySpawner _instance;
    public static EnemySpawner Instance => _instance;
    static public string chicken_1 = "Chicken_1";
    public event EventHandler<EventArgs> OnAllChikenDead;
    protected override void Awake()
    {
        base.Awake();
        this.LoadSingleton();   
    }
    public virtual Transform Spawn(EnemySO chickenSO,Vector3 pos,Quaternion rot)
    {
       return base.Spawn(chickenSO.name, pos, rot);
    }
    protected virtual void LoadSingleton()
    {
        if (EnemySpawner._instance != null)
        {
            Debug.LogError("There are have more than one ChickenSpawner");
            return;
        }
        EnemySpawner._instance = this;
    }
    public override void Despawn(Transform obj)
    {
        base.Despawn(obj);
        this.CheckAllChickenDead();
    }
    protected virtual void CheckAllChickenDead()
    {
        if (this.spawnCount > 0) return;
        this.OnAllChikenDead?.Invoke(this,EventArgs.Empty);
    }
}
