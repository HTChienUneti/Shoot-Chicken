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
        List<ItemDrop> itemDrop = this.chickenCtrl.ChickenSO.itemDrop;
       
        float  rate = Random.Range(0.0f,1.0f);
        float dropRate;
        foreach (ItemDrop drop in itemDrop)
        {
            dropRate = drop.dropRate/100000;
            if (dropRate < rate) continue;
            Transform item = ItemSpawner.Instance.Spawn(drop.itemName, transform.position, transform.rotation);
            if (item == null) return;
            item.gameObject.SetActive(true);
            break;
        }
      
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
