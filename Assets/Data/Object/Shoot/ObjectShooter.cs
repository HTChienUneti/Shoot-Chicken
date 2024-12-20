using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectShooter : ObjectShooterAbstract
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
        GameActiveState.Instance.OnEnterState += GameActiveState_OnEnterState;
        GameActiveState.Instance.OnExitState += GameActiveState_OnExitState;
    }

    private void GameActiveState_OnExitState(object sender, System.EventArgs e)
    {
        this.isBlockShoot = true;
    }

    private void GameActiveState_OnEnterState(object sender, System.EventArgs e)
    {
        this.isBlockShoot = false;
    }

    public virtual void SetDamaging(string damagingName)
    {
        this.GetDamagingSOByName(damagingName);
    }

    public virtual void GetDamagingSOByName(string name)
    {
        string path = "SO/Damaging/" + name;
        this.damagingSO = Resources.Load<DamagingSO>(path);
        this.SetDamaging(damagingSO);
    }

    public virtual void SetDamaging(DamagingSO damagingSO)
    {
        this.damagingSO = damagingSO;
        this.currentDamaging = this.damagingSO;
        this.OnChangedObjDamaging();
    }
    public virtual DamagingSO GetDamaging()
    {
        return this.damagingSO;
    }
    protected override void ResetValue()
    {
        base.ResetValue();
        this.shootTimer = shootDelay;
    }

    protected virtual void FixedUpdate()
    {
        this.Shooting();
    //    this.CountdownTime();
    }
    protected virtual bool Shooting()
    {
        if (this.isBlockShoot || !this.CountdownTime()) return false;
        if (!this.autoShoot)
            if (!this.isShooting) return false;

        List<Transform> damagings = new List<Transform>();
        for (int i = 0; i < this.shooterLevel.CurrentLevel; i++)
        {
            Transform damaging = this.GetPrefab();
            if(damaging == null) continue;
            damagings.Add(this.GetPrefab());
        }
        if (damagings == null || damagings.Count == 0) return false;
        this.SetPrefabPos(damagings);
        foreach (Transform prefab in damagings)
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
    protected virtual bool CountdownTime()
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

    public void OnChangedObjDamaging()
    {
        foreach (IShooterChangeDamaging listener in this.listeners)
        {
            listener.OnChangedObjDamaging(this.currentDamaging);
        }
    }
    public virtual void Shoot(DamagingSO damaging)
    {
        Transform bullet = BulletSpawner.Instance.Spawn(damaging, this.startPos.position, Quaternion.identity);
        bullet.gameObject.SetActive(true);
    }
}
