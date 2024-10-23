using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectShooter : MyMonoBehaviour
{
    [Header("Obj Shooter")]
    [SerializeField] protected float shootDelay = 1f;
    [SerializeField] protected float shootTimer = 0f;
    [SerializeField] protected float distance = 0.5f;
    [SerializeField] protected Transform startPos;

    [SerializeField] protected ShooterLevel shooterLevel;
    public ShooterLevel ShooterLevel => shooterLevel;

    protected DamagingSO damagingSO;
    public DamagingSO DamagingSO => damagingSO;
    // [SerializeField] protected string damagingName;
    [SerializeField] protected DamagingSO currentDamaging;
    public DamagingSO CurrentDamaging => currentDamaging;

    public virtual void SetDamaging(DamagingSO damagingSO)
    {
        this.damagingSO = damagingSO;
        this.currentDamaging = this.damagingSO;
    }
    public virtual void SetDamaging(string damagingName)
    {
        string name = damagingName;
        this.GetDamagingSOByName(name);
    }
    public virtual void GetDamagingSOByName(string name)
    {
        string path = "SO/Damaging/" + name;
        this.damagingSO = Resources.Load<DamagingSO>(path);
        this.currentDamaging = this.damagingSO;
    }
    protected abstract string GetDamagingName();

    protected override void ResetValue()
    {
        base.ResetValue();
        this.shootTimer = shootDelay;
    }

    protected virtual void FixedUpdate()
    {
        this.Shooting();
    }
    protected virtual void Shooting()
    {
        if (!this.CountdownTime()) return;
        List<Transform> prefabs = new List<Transform>();
        for (int i = 0; i < this.shooterLevel.CurrentLevel; i++)
        {
            prefabs.Add(this.GetPrefab());
        }
        if (prefabs == null) return;
        if (prefabs.Count == 0) return;
        this.SetPrefabPos(prefabs);
        foreach (Transform prefab in prefabs)
        {
            if (prefab == null) continue;
            prefab.gameObject.SetActive(true);
        }
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
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadStartPos();
        this.LoadShooterLevel();
        this.LoadDamagingSO();
    }
    protected virtual void LoadDamagingSO()
    {
        if (this.damagingSO != null) return;
        string damagingName = this.GetDamagingName();
        string path = "SO/Damaging/" + damagingName;
        this.damagingSO = Resources.Load<DamagingSO>(path);
        this.currentDamaging = this.damagingSO;
        Debug.LogWarning(transform.name + ": LoadStartPos", gameObject);
    }
    protected virtual void LoadShooterLevel()
    {
        if (this.shooterLevel != null) return;
        this.shooterLevel = GetComponentInChildren<ShooterLevel>();
        Debug.LogWarning(transform.name + ": LoadStartPos", gameObject);
    }

    protected virtual void LoadStartPos()
    {
        if (this.startPos != null) return;
        this.startPos = transform.Find("StartPos");
        Debug.LogWarning(transform.name + ": LoadStartPos", gameObject);
    }

}
