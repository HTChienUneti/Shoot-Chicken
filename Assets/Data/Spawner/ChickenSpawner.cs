using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenSpawner : Spawner
{
    [Header("ChickenSpawner")]
    private static ChickenSpawner _instance;
    public static ChickenSpawner Instance => _instance;
    static public string chicken_1 = "Chicken_1";
    protected List<IUsingAllChickenDead> listeners = new List<IUsingAllChickenDead>();

    protected override void Awake()
    {
        base.Awake();
        this.LoadSingleton();
    }
    protected virtual void LoadSingleton()
    {
        if (ChickenSpawner._instance != null)
        {
            Debug.LogError("There are have more than one ChickenSpawner");
            return;
        }
        ChickenSpawner._instance = this;
    }
    public override void Despawn(Transform obj)
    {
        base.Despawn(obj);
        this.CheckAllChickenDead();
    }
    protected virtual void CheckAllChickenDead()
    {
        if (this.spawnCount > 0) return;
        OnAllChickenDead();

    }
    public virtual void AddListener(IUsingAllChickenDead listener)
    {
        this.listeners.Add(listener);
    }
    public virtual void RemoveListener(IUsingAllChickenDead listener)
    {
        this.listeners.Remove(listener);
    }
    public virtual void OnAllChickenDead()
    {
        foreach (IUsingAllChickenDead listener in this.listeners)
        {
            listener.OnAllChickenDead();
        }
    }
}
