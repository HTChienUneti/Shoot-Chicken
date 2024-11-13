using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectShooterAbstract : MyMonoBehaviour
{
    [Header("ObjectShooter Abstract")]
    [SerializeField] protected Transform startPos;

    [SerializeField] protected ShooterLevel shooterLevel;
    public ShooterLevel ShooterLevel => shooterLevel;

    [SerializeField]protected DamagingSO damagingSO;
    public DamagingSO DamagingSO => damagingSO;
    // [SerializeField] protected string damagingName;
    [SerializeField] protected DamagingSO currentDamaging;
    public DamagingSO CurrentDamaging => currentDamaging;

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
        Debug.LogWarning(transform.name + ": LoadDamagingSO", gameObject);
    }
    protected abstract string GetDamagingName();

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
