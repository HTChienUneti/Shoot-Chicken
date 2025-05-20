using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : Spawner
{
    [Header("Item Spawner")]
    private static ItemSpawner _instance;
    public static ItemSpawner Instance => _instance;
    static public string item_1 = "Item_1";

    protected override void Awake()
    {
        base.Awake();
        this.LoadSingleton();
    }
    
    protected virtual void LoadSingleton()
    {
        if (ItemSpawner._instance != null)
        {
            Debug.LogError("There are have more than 1 ItemSpawner");
            return;
        }
        ItemSpawner._instance = this;
    }
}
