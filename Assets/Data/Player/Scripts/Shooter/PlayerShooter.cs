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

    protected override void Awake()
    {
        base.Awake();
        this.LoadSingleton();
    }
    protected override Transform GetPrefab()
    {
        Transform newBullet = BulletSpawner.Instance.Spawn(this.currrenWeapon, this.startPos.position, Quaternion.identity);
        if(newBullet == null) return newBullet;
        newBullet.GetComponent<BulletCtrl>().SetShooter(transform.parent);
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
        this.isShooting = false;
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
        return this.playerCtrl.PlayerSO.weapons.Cast<WeaponSO>().ToList();
    }

    #region LoadComponent
    protected override void LoadComponent()
    {
        this.LoadPlayerCtrl();
        base.LoadComponent();

    }
    protected virtual void LoadPlayerCtrl()
    {
        if (this.playerCtrl != null) return;
        this.playerCtrl = transform.parent.GetComponent<PlayerCtrl>();
        Debug.LogWarning(transform.name + ": LoadPlayerCtrl", gameObject);
    }
    #endregion
}
