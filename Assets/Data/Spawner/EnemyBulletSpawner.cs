using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletSpawner : Spawner
{
    [Header("EggSpawner")]
    private static EnemyBulletSpawner _instance;
    public static EnemyBulletSpawner Instance => _instance;
    static public string egg_1 = "Egg_1";
    protected override void Awake()
    {
        base.Awake();
        this.LoadSingleton();
    }
    
    protected virtual void LoadSingleton()
    {
        if (EnemyBulletSpawner._instance != null)
        {
            Debug.LogError("There are have more than 1 EggSpawner");
            return;
        }
        EnemyBulletSpawner._instance = this;
    }
    public virtual Transform Spawn(WeaponSO damagingSO, Vector3 pos, Quaternion rot)
    {
        return  base.Spawn(damagingSO.name, pos, rot);
    }
}
