using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class PlayerPickupItem : PlayerAbstract
{
    [Header("Player Pickup Item")]
    [SerializeField] protected SphereCollider _collider;
    private void OnTriggerEnter(Collider other)
    {
        ItemPickupAble itemPickupAble = other.GetComponent<ItemPickupAble>();
        if (itemPickupAble == null) return;
        itemPickupAble.Picked();
        this.playerCtrl.Inventory.AddItem(itemPickupAble.ItemCtrl.ItemDrop,1);
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
        this._collider.radius = 1f;
        this._collider.isTrigger = true;
        Debug.LogWarning(transform.name + ": LoadCollier", gameObject);
    }
}
