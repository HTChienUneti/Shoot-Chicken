using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagingObjCtrl : MyMonoBehaviour,IGameActiveState
{
    [SerializeField] protected DamageSender damageSender;
    public DamageSender DamageSender=>damageSender;
     [SerializeField] protected DamagingSO damagingSO;
    public DamagingSO DamagingSO => damagingSO;
    [SerializeField] protected Transform shooter;
    [SerializeField] protected SpriteRenderer model;
    public Transform Shooter => shooter;
    protected override void Start()
    {
        base.Start();
        GameActiveState.Instance.Add(this);
    }
    public virtual void SetShooter(Transform shooter)
    {
        this.shooter = shooter;
    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadDamageSender();
        this.LoadDamagingSO();
        this.LoadModel();
    }
    protected virtual void LoadModel()
    {
        if (this.model != null) return;
        this.model = GetComponentInChildren<SpriteRenderer>();
        this.model.sprite = this.damagingSO._sprite;
        Debug.LogWarning(transform.name + ": LoadModel", gameObject);
    }
    protected virtual void LoadDamageSender()
    {
        if (this.damageSender != null) return;
        this.damageSender = GetComponentInChildren<DamageSender>();
        Debug.LogWarning(transform.name + " :LoadDamageSender", gameObject);
    }

    protected virtual void LoadDamagingSO()
    {
        if (this.damagingSO != null) return;
        string path = "SO/Damaging/" + transform.name;
        this.damagingSO = Resources.Load<DamagingSO>(path); 
      
        Debug.LogWarning(transform.name + " :LoadDamagingSO", gameObject);
    }

    public virtual void EnterState()
    {
        
    }

    public virtual void ExcuseState()
    {
        throw new System.NotImplementedException();
    }

    public virtual void ExitState()
    {
        
    }
}
