using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : Spawner
{
    [Header("BulletSpawner")]
    private static BulletSpawner _instance;
    public static BulletSpawner Instance => _instance;
    static public string Bullet_1 = "Bullet_1";

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

}
