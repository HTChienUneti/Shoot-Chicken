using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public abstract class DamageReceiver : MyMonoBehaviour
{
    [SerializeField] protected SphereCollider _collider;
    public SphereCollider Collider=> _collider;
    [SerializeField] protected int hp;
    [SerializeField] protected int hpMax = 10;
    [SerializeField] protected bool isDead = false;
    protected override void Start()
    {
        base.Start();
        this.hp = this.hpMax;
    }
    protected override void ResetValue()
    {
        base.ResetValue();
        this.hp = this.hpMax; 
    }
    public virtual void ReduceHp(int hp)
    {
        this.hp -= hp;
        this.CheckDead();
    }
    protected virtual void CheckDead()
    {
        if (this.hp > 0) return;
        this.isDead = true;
        this.OnDead();

    }
    protected virtual void OnDead()
    {
        this.CreateVFXDead();
        this.Despawn();
    }
    protected abstract void Despawn();
    protected virtual void CreateVFXDead()
    {

    }
    public virtual void AddHp(int hp)
    {
        this.hp += hp;
    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadCollider();

    }
    protected virtual void LoadCollider()
    {
        if (this._collider != null) return;
        this._collider = GetComponent<SphereCollider>();
        this._collider.radius = .2f;
        this._collider.isTrigger = true;
        Debug.LogWarning(transform.name + ": LoadCollier", gameObject);
    }
}
