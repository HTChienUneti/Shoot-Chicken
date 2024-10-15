using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenDamageReceiver : DamageReceiver
{
    protected override void ResetValue()
    {
        this.Collider.radius = .4f;
        this.hpMax = 1;
        base.ResetValue();

    }
    protected override void OnDead()
    {
        ChickenSpawner.Instance.Despawn(transform.parent);
        this.DropItem();
        base.OnDead();
    }
    protected virtual void DropItem()
    {
        string itemName = ItemSpawner.item_1;
        Transform item = ItemSpawner.Instance.Spawn(itemName, transform.position, transform.rotation);
        if (item == null) return;
        item.gameObject.SetActive(true);
    }
 
    protected override void CreateVFXDead()
    {
        string prefabName = VFXSpawner.boom_1;
        Transform prefab = VFXSpawner.Instance.Spawn(prefabName,transform.position,transform.rotation);
        if (prefab == null) return;
        prefab.gameObject.SetActive(true);
    }
}
