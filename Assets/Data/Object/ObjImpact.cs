using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
public abstract class ObjImpact: MyMonoBehaviour
{
    [Header("Obj Impact")]
    [SerializeField] protected Rigidbody2D _rigid;
    [SerializeField] protected CircleCollider2D _collider;
    [SerializeField] protected DamageReceiver damageReceiver;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(this.CheckShootSelf(collision)) return;
        this.Despawn();
        this.GetDamageReceiver(collision);
        if (this.damageReceiver == null) return;
        this.SendDamage();
        
    }
    protected abstract bool CheckShootSelf(Collider2D collision);
    protected virtual void GetDamageReceiver(Collider2D collision)
    {
        this.damageReceiver= collision.transform.GetComponent<DamageReceiver>();
    }
    protected abstract void SendDamage();
    protected abstract void Despawn();

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadCollier();
        this.LoadRigid();
    }
    protected virtual void LoadCollier()
    {
        if (this._collider != null) return;
        this._collider = GetComponent<CircleCollider2D>();
        this._collider.radius = .2f;
        Debug.LogWarning(transform.name + ": LoadCollier", gameObject);
    }
    protected virtual void LoadRigid()
    {
        if (this._rigid != null) return;
        this._rigid = GetComponent<Rigidbody2D>();

        Debug.LogWarning(transform.name + ": LoadRigid", gameObject);
    }
}
