using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenShooter : ObjectShooter
{
    [SerializeField] protected ChickenCtrl chickenCtrl;
    public ChickenCtrl ChickenCtrl => chickenCtrl;

    protected override void ResetValue()
    {
        this.shootTimer = 0f;
        this.shootDelay = Random.Range(1, this.shootDelay);
    }
    protected override string GetPrefabName()
    {
        return EggSpawner.egg_1;
    }
    protected override Transform GetPrefab()
    {
        Transform newPrefab = EggSpawner.Instance.Spawn(this.prefabName, this.startPos.position, Quaternion.identity);
        if (newPrefab == null) return null;
        newPrefab.GetComponent<EggCtrl>().SetShooter(this);
        return newPrefab;

    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadChickenCtrl();
    }
    protected override void Shooting()
    {
        base.Shooting();
    }
    protected virtual void LoadChickenCtrl()
    {
        if (this.chickenCtrl != null) return;
        this.chickenCtrl = transform.parent.GetComponent<ChickenCtrl>();

        Debug.LogWarning(transform.name + ": LoadChickenCtrl", gameObject);
    }
}
