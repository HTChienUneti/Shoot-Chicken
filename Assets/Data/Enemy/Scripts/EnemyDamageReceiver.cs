using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageReceiver : DamageReceiver
{
    [Header("Enemy DamageReceiver")]
    [SerializeField] protected EnemyCtrl enemyCtrl;
    [SerializeField] protected float gameDropRate =1;
    protected override void ResetValue()
    {
        this.hpMax = this.enemyCtrl.WeaponSO.maxHp;
        base.ResetValue();
    }
    public override void ReduceHp(int hp)
    {
        base.ReduceHp(hp);
    }
    protected override void OnDead()
    { 
        this.DropItem();
        base.OnDead();
       
    }
    protected virtual void DropItem()
    {
        List<ItemDropRate> itemDrop = this.enemyCtrl.WeaponSO.itemDrop;
       
        float  rate = Random.Range(0.0f,1.0f) ;
        float dropRate;
        foreach (ItemDropRate drop in itemDrop)
        {
            dropRate = (drop.rate/100000) * this.gameDropRate;
            if (dropRate < rate) continue;
            Transform item = ItemSpawner.Instance.Spawn(drop.itemDrop.itemProfile.itemCode.ToString(), transform.position, transform.rotation);
            if (item == null) return;
            item.gameObject.SetActive(true);
            break;
        }
      
    }
    protected override void LoadCollider()
    {
        base.LoadCollider();
        this._collider.radius = .5f;
    }

    protected override string GetVfxName()
    {
        return VFXSpawner.boom_1;
    }
    protected override void Despawn()
    {
        EnemySpawner.Instance.Despawn(transform.parent);
    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadEnemyCtrl();
    }
    protected virtual void LoadEnemyCtrl()
    {
        if (this.enemyCtrl != null) return;
        this.enemyCtrl = transform.parent.GetComponent<EnemyCtrl>();
        Debug.LogWarning(transform.name + ": LoadEnemyCtrl", gameObject);
    }
}
