using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyShooter : ObjectShooter
{
    [SerializeField] protected EnemyCtrl enemyCtrl;
    public EnemyCtrl EnemyCtrl => enemyCtrl;

    protected override void ResetValue()
    {
        this.shootTimer = 0f;
        this.autoShoot = true;
        this.shootDelay = Random.Range(5, this.shootDelay);
    }
    protected override Transform GetPrefab()
    {
        Transform newPrefab = EnemyBulletSpawner.Instance.Spawn(this.weapons[0], this.startPos.position, Quaternion.identity);
        if (newPrefab == null) return null;
        newPrefab.GetComponent<EnemyBulletCtrl>().Shooter = transform.parent;
        return newPrefab;

    }   

    protected override void LoadComponent()
    {
        this.LoadEnemyCtrl();
        base.LoadComponent();
       
    }
    protected override bool Shooting()
    {
        return base.Shooting();
    }
    protected virtual void LoadEnemyCtrl()
    {
        if (this.enemyCtrl != null) return;
        this.enemyCtrl = transform.parent.GetComponent<EnemyCtrl>();

        Debug.LogWarning(transform.name + ": LoadEnemyCtrl", gameObject);
    }

    protected override string GetWeaponName()
    {
        return this.enemyCtrl.EnemySO.weapons[0].name;
    }

    protected override List<WeaponSO> GetWeaponSO()
    {
        return this.enemyCtrl.EnemySO.weapons.Cast<WeaponSO>().ToList();
    }
}
