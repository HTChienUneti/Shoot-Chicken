using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCtrl : WeaponCtrl
{
    [SerializeField] protected EnemyMovement enemyMovement;
    public EnemyMovement EnemyMovement => enemyMovement;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadEnemyMovement();
    }
    protected virtual void LoadEnemyMovement()
    {
        if (this.enemyMovement != null) return;
        this.enemyMovement = GetComponentInChildren<EnemyMovement>();

        Debug.LogWarning(transform.name + ": LoadEnemyMovement", gameObject);
    }

    protected override string GetPathToLoadWeaponSO()
    {
        return "SO/Weapon/Enemy/";
    }
}
