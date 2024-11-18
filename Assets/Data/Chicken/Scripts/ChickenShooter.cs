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
        this.autoShoot = true;
        this.shootDelay = Random.Range(5, this.shootDelay);
    }
    protected override Transform GetPrefab()
    {
        Transform newPrefab = EggSpawner.Instance.Spawn(this.damagingSO, this.startPos.position, Quaternion.identity);
        if (newPrefab == null) return null;
        newPrefab.GetComponent<EggCtrl>().SetShooter(transform.parent);
        return newPrefab;

    }   

    protected override void LoadComponent()
    {
        this.LoadChickenCtrl();
        base.LoadComponent();
       
    }
    protected override bool Shooting()
    {
        return base.Shooting();
    }
    protected virtual void LoadChickenCtrl()
    {
        if (this.chickenCtrl != null) return;
        this.chickenCtrl = transform.parent.GetComponent<ChickenCtrl>();

        Debug.LogWarning(transform.name + ": LoadChickenCtrl", gameObject);
    }

    protected override string GetDamagingName()
    {
        return this.chickenCtrl.ChickenSO.damaging.damagingName;
    }
}
