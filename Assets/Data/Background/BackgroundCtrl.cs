using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundCtrl : MyMonoBehaviour
{
    [SerializeField] protected SpawnBackground spawnBackground;
    public SpawnBackground SpawnBackground => spawnBackground;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadSpawnBackground();
    }
    protected virtual void LoadSpawnBackground()
    {
        if (this.spawnBackground != null) return;
        this.spawnBackground = GetComponentInChildren<SpawnBackground>();
        Debug.LogWarning(transform.name + ": LoadSpawnBackground", gameObject);
    }
}
