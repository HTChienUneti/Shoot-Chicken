using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : Spawner
{
    
    [Header("BulletSpawner")]
    private static BulletSpawner _instance;
    public static BulletSpawner Instance => _instance;
    public enum Bullet
    {
        Bullet_blue=1,
        Bullet_red=2,
        Bullet_green=3,
        Bullet_purple=4,
    }

    protected override void Awake()
    {
        base.Awake();
        this.LoadSingleton();
    }
    protected virtual void LoadSingleton()
    {
        if (BulletSpawner._instance != null)
        {
            Debug.LogError("There are have more than 1 BulletSpawner");
            return;
        }
        BulletSpawner._instance = this;
    }
    public virtual Transform Spawn(WeaponSO damagingSO,Vector3 pos, Quaternion rot)
    {
         return base.Spawn(damagingSO.name, pos, rot);  
    }

}
