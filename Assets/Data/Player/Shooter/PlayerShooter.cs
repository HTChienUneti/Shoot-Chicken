using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class PlayerShooter : ObjectShooter
{
    static private PlayerShooter _instance;
    static public PlayerShooter Instance=>_instance;
    public event EventHandler<EventArgs> OnShooting;
    [SerializeField] protected PlayerCtrl playerCtrl;
    public PlayerCtrl PlayerCtrl => playerCtrl;
    [SerializeField] protected PlayerShootByMouse shooterByMouse;
    public PlayerShootByMouse ShooterByMouse => shooterByMouse;
    [SerializeField] protected PlayerShootByKey shooterByKey;
    public PlayerShootByKey PlayerShooterByKey => shooterByKey;

    protected override void Awake()
    {
        base.Awake();
        this.LoadSingleton();
    }
    protected override Transform GetPrefab()
    {
        Transform newBullet = BulletSpawner.Instance.Spawn(this.damagingSO, this.startPos.position, Quaternion.identity);
        return newBullet;
    }

    protected override string GetDamagingName()
    {
        return "Bullet_Blue";
    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadPlayerCtrl();
    }
    protected override bool Shooting()
    {
        if(!base.Shooting()) return false;
        this.OnShooting?.Invoke(this, EventArgs.Empty);
        this.isShooting = false;
        return true;
    }
    protected virtual void LoadPlayerCtrl()
    {
        if (this.playerCtrl != null) return;
        this.playerCtrl = transform.parent.GetComponent<PlayerCtrl>();
        Debug.LogWarning(transform.name + ": LoadPlayerCtrl", gameObject);
    }

    public void SetShooting(bool isShooting)
    {
        this.isShooting = isShooting;
    }
    protected virtual void LoadShooterByKey()
    {
        if (this.shooterByKey != null) return;
        this.shooterByKey = GetComponentInChildren<PlayerShootByKey>();
        Debug.Log(transform.name + ": LoadShooterByKey", gameObject);
    }

    private void LoadSingleton()
    {
        if(PlayerShooter._instance != null)
        {
            Debug.LogError("There are already have a PlayerShooter!", gameObject);
            return;
        }
        PlayerShooter._instance = this;
    }
}
