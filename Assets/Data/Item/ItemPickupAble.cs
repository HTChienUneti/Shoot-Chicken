using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(Rigidbody))]
public class ItemPickupAble : ItemAbstract
{
    [SerializeField] protected SphereCollider _collider;
    [SerializeField] protected Rigidbody _rigid;
    public virtual void Picked()
    {
        Debug.Log("picked");
    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadCollider();
        this.LoadRigidbody();
    }
    protected virtual void LoadRigidbody()
    {
        if (this._rigid != null) return;
        this._rigid = GetComponent<Rigidbody>();
        this._rigid.isKinematic = false;
        Debug.LogWarning(transform.name + ": LoadRigidbody", gameObject);
    }
    protected virtual void LoadCollider()
    {
        if (this._collider != null) return;
        this._collider = GetComponent<SphereCollider>();
        this._collider.radius = .5f;
        this._collider.isTrigger = true;
        Debug.LogWarning(transform.name + ": LoadCollier", gameObject);
    }
}
