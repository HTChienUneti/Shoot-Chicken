using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCtrl : EnemyCtrl
{
    [SerializeField] protected HealthBar healthBar;
    public HealthBar HealthBar=>healthBar;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadHealthBar();
    }
    protected virtual void LoadHealthBar()
    {
        if (this.healthBar != null) return;
        this.healthBar = GetComponentInChildren<HealthBar>();
        Debug.Log(transform.name + ": LoadHealthBar", gameObject);
    }
}
