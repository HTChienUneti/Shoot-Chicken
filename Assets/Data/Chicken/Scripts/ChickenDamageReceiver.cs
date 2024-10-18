using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenDamageReceiver : DamageReceiver
{
    [SerializeField] protected ChickenCtrl chickenCtrl;
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
        //to do
        int intdex = Random.Range(0, this.chickenCtrl.ChickenSO.itemDrop.Count);
        string itemName = this.chickenCtrl.ChickenSO.itemDrop[intdex].itemName;
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
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadChickenCtrl();
    }
    protected virtual void LoadChickenCtrl()
    {
        if (this.chickenCtrl != null) return;
        this.chickenCtrl = transform.parent.GetComponent<ChickenCtrl>();
        Debug.LogWarning(transform.name + ": LoadChickenCtrl", gameObject);
    }
}
