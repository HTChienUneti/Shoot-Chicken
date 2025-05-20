using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

public class PlayerShooter : ObjectShooter
{
    static private PlayerShooter _instance;
    static public PlayerShooter Instance=>_instance;
    public event EventHandler<EventArgs> OnShooting;
    [SerializeField] protected PlayerCtrl playerCtrl;
    public PlayerCtrl PlayerCtrl => playerCtrl;
    [SerializeField] protected ChangeWeaponManager changeWeaponManager;
    public ChangeWeaponManager ChangeWeaponManager => changeWeaponManager;

    [SerializeField] protected PlayerShooterSO playerShooterSO;
    public PlayerShooterSO PlayerShooterSO => playerShooterSO;

    protected override void Awake()
    {
        base.Awake();
        this.LoadSingleton();
    }
    protected override void ResetValue()
    {
        base.ResetValue();
        this.shootDelay = .3f;
        this.shootTimer = 0;
    }
    protected override Transform GetPrefab()
    {
        Transform newBullet = BulletSpawner.Instance.Spawn(this.currrenWeapon, this.startPos.position, Quaternion.identity);
        if(newBullet == null) return newBullet;
        newBullet.GetComponent<BulletCtrl>().Shooter =transform.parent;
        return newBullet;
    }

    protected override string GetWeaponName()
    {
        return "Bullet_Blue";
    }

    protected override bool Shooting()
    {
        if(!base.Shooting()) return false;
        this.OnShooting?.Invoke(this, EventArgs.Empty);
        base.BlockShoot();
        return true;
    }
 
    public void SetShooting(bool isShooting)
    {
        this.isShooting = isShooting;
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

    protected override List<WeaponSO> GetWeaponSO()
    {
        return this.playerShooterSO.weapons.Cast<WeaponSO>().ToList();
    }

    #region LoadComponent
    protected override void LoadComponent()
    {
        this.LoadPlayerCtrl();
        base.LoadComponent();
        this.LoadChangeWeaponManager();
        this.LoadPlayerShooterSO();

    }
    protected virtual void LoadPlayerShooterSO()
    {
        if (this.playerShooterSO != null) return;
        string path = "SO/Player/Shooter/" + transform.name;
        this.playerShooterSO = Resources.Load<PlayerShooterSO>(path);
        Debug.LogWarning(transform.name + ": LoadPlayerShooterSO", gameObject);
    }

    protected virtual void LoadChangeWeaponManager()
    {
        if (this.changeWeaponManager != null) return;
        this.changeWeaponManager = GetComponentInChildren<ChangeWeaponManager>();   
        Debug.LogWarning(transform.name + ": LoadChangeWeaponManager", gameObject);
    }
    protected virtual void LoadPlayerCtrl()
    {
        if (this.playerCtrl != null) return;
        this.playerCtrl = transform.parent.GetComponent<PlayerCtrl>();
        Debug.LogWarning(transform.name + ": LoadPlayerCtrl", gameObject);
    }
    #endregion
}
