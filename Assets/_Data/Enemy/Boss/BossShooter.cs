using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShooter : EnemyShooter
{
    [Header("Boss Shooter")]
    [SerializeField] protected int DamagingCount;
    [SerializeField] protected int DamagingMax = 10;
    [SerializeField] protected float reShootingTime = 4f;
    [SerializeField] protected float startShootDelay = 4f;
    [SerializeField] protected bool isStart = false;
    protected override void ResetValue()
    {
        base.ResetValue();
        this.shootDelay = 0.5f;
    }
    protected override void Start()
    {
        base.Start();
        StartCoroutine(nameof(this.StartShootDelay));
    }
    protected override bool Shooting()
    {
        if (!this.isStart) return false;
        if(base.Shooting())
        {
            this.DamagingCount++;
            if (this.DamagingCount < this.DamagingMax) return true;
            this.isBlockShoot = true;
            StartCoroutine(nameof(this.Reshooting));
            return true;
        }
        return false;
    }
    protected IEnumerator StartShootDelay()
    {
        yield return new WaitForSeconds(this.startShootDelay);
        this.isStart = true;
    }
    protected IEnumerator Reshooting()
    {
        yield return new WaitForSeconds(this.reShootingTime);
        this.isBlockShoot = false;
        this.DamagingCount = 0;
    }
}
