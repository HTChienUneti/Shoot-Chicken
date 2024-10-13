using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenShooter : ObjectShooter
{
    [SerializeField] protected ChickenCtrl chickenCtrl;
    public ChickenCtrl ChickenCtrl=> chickenCtrl;
    protected override string GetPrefabName()
    {
        return EggSpawner.egg_1;
    }
    protected override Transform GetPrefab()
    {
        Transform prefab = EggSpawner.Instance.Spawn(this.prefabName, this.startPos.position, Quaternion.identity);
      
        prefab.GetComponent<EggCtrl>().SetShooter(this);
        return prefab;
    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadChickenCtrl();
    }
    protected virtual void LoadChickenCtrl()
    {
        if (this.chickenCtrl != null) return;
        this.chickenCtrl = transform.parent.GetComponent<ChickenCtrl>();

        Debug.LogWarning(transform.name + ": LoadChickenCtrl", gameObject);
    }
}
