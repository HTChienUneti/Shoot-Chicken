using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectShooter : ObjectShooterBase
{
    [Header("Obj Shooter")]
    [SerializeField] protected float shootDelay = 1f;
    [SerializeField] protected float shootTimer = 0f;
    [SerializeField] protected float distance = 0.5f;
    [SerializeField] protected bool isShooting = false;
    [SerializeField] protected bool isBlockShoot = false;
    [SerializeField] protected bool autoShoot = false;
    protected List<IShooterChangeDamaging> listeners = new List<IShooterChangeDamaging>();
    protected override void Start()
    {
        base.Start();
        PlayingGameState.Instance.OnEnterState += GamePlayingState_OnEnterState;
        PlayingGameState.Instance.OnExitState += GamePlaying_OnExitState;
        this.isBlockShoot = true;
    }
    public virtual void BlockShoot()
    {
        this.isBlockShoot = true;
    }
    public virtual void CanShoot()
    {
        this.isBlockShoot = false;
    }
    private void GamePlaying_OnExitState(object sender, System.EventArgs e)
    {
        this.isBlockShoot = true;

    }
    private void GamePlayingState_OnEnterState(object sender, System.EventArgs e)
    {
        //this.isBlockShoot = false;
    }

    public virtual void SetDamaging(string damagingName)
    {
        this.GetDamagingSOByName(damagingName);
    }

    public virtual void GetDamagingSOByName(string name)
    {
        foreach(WeaponSO  weapon in this.weapons)
        {
            if (weapon.name != name) continue;
            this.SetWeapon(weapon);
        }
    }   

    public virtual void SetWeapon(WeaponSO weaponSO)
    {
        this.currrenWeapon = weaponSO;
        this.OnChangedWeapon();
    }
    public virtual WeaponSO GetDamaging()
    {
        return this.currrenWeapon;
    }
    protected override void ResetValue()
    {
        base.ResetValue();
        this.shootTimer = shootDelay;
    }

    protected virtual void FixedUpdate()
    {
        this.Shooting();
    }
    protected virtual bool Shooting()
    {
        if(autoShoot)
        {
            this.isBlockShoot = false;
        }
        else
        {
            if (this.isBlockShoot) return false;
        }
        if (!this.ReloadingBullet()) return false;
        List<Transform> bullets = new List<Transform>();
        for (int i = 0; i < this.shooterLevel.CurrentLevel; i++)
        {
            Transform damaging = this.GetPrefab();
            if(damaging == null) continue;
            bullets.Add(this.GetPrefab());
        }
        if (bullets == null || bullets.Count == 0) return false;
        this.SetPrefabPos(bullets);
        foreach (Transform prefab in bullets)
        {
            if (prefab == null) continue;
            prefab.gameObject.SetActive(true);
        }
        return true;
    }
    protected virtual void SetPrefabPos(List<Transform> prefabs)
    {
        if (prefabs.Count == 0) return;
        int count = prefabs.Count;
        int index = 0;
        Vector3 left, right;
        //calculator for the first prefab left and right beside the shooter
        float dis = this.distance;
        if (count % 2 == 0)
        {
            dis = this.distance / 2;
        }
        left = this.startPos.position + new Vector3(-dis, 0, 0);
        right = this.startPos.position + new Vector3(dis, 0, 0);
        for (int i = 0; i < count / 2; i++)
        {
            prefabs[index].position = left;
            index++;
            left += new Vector3(-distance, 0, 0);
            prefabs[index].position = right;
            index++;
            right += new Vector3(distance, 0, 0);
        }
    }
    protected abstract Transform GetPrefab();
    protected virtual bool ReloadingBullet()
    {
        this.shootTimer += Time.fixedDeltaTime;
        if (this.shootTimer < this.shootDelay) return false;
        this.shootTimer = 0f;
        return true;
    }

    public virtual void AddListener(IShooterChangeDamaging listener)
    {
        this.listeners.Add(listener);
    }
    public virtual void RemoveListener(IShooterChangeDamaging listener)
    {
        this.listeners.Remove(listener);
    }

    public void OnChangedWeapon()
    {
        foreach (IShooterChangeDamaging listener in this.listeners)
        {
            listener.OnChangedObjDamaging(this.currrenWeapon);
        }
    }
    public virtual void Shoot(WeaponSO damaging)
    {
        Transform bullet = BulletSpawner.Instance.Spawn(damaging, this.startPos.position, Quaternion.identity);
        bullet.gameObject.SetActive(true);
    }
}
