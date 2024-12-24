using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public abstract class DamageReceiver : MyMonoBehaviour
{
    public event EventHandler<OnChangedHpEventArgs> OnChangedHp;
    public class OnChangedHpEventArgs : EventArgs
    {
        public int hp;
    }

    [SerializeField] protected SphereCollider _collider;
    public SphereCollider Collider => _collider;
    [SerializeField] protected int currentHp;
    public int CurrentHp => currentHp;
    [SerializeField] protected int hpMax = 10;
    public int HpMax => hpMax;
    [SerializeField] protected bool isDead = false;
    protected override void ResetValue()
    {
        this.currentHp = this.hpMax; 
    }
    public virtual void ReduceHp(int hp)
    {
        this.currentHp -= hp;
        if (this.currentHp < 0)
        {
            this.currentHp = 0;
        }
        this.CreateVfXReceiveDamage();
        this.OnChangedHp?.Invoke(this, new OnChangedHpEventArgs
        {
            hp = this.currentHp
        }); 

        this.CheckDead();
  
    }
    protected virtual void CreateVfXReceiveDamage()
    {

    }
    protected virtual void CheckDead()
    {
        if (this.currentHp > 0) return;
        this.isDead = true;
        this.OnDead();

    }
    protected virtual void OnDead()
    {
        this.CreateVFXDead();
        this.Despawn();
    }
    protected virtual void Despawn()
    {

    }
    protected virtual void CreateVFXDead()
    {

    }
    public virtual void AddHp(int hp)
    {
        this.currentHp += hp;
        if(this.currentHp> this.hpMax)
        {
            this.currentHp = this.hpMax;
        }
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
