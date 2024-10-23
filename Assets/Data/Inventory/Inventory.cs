using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : PlayerAbstcract
{
    [SerializeField] protected List<ItemDrop> items;
    public virtual void AddItem(ItemDrop item)
    {
        if (this.playerCtrl.Shooter.CurrentDamaging.damagingName == item.name)
        {
            this.playerCtrl.Shooter.ShooterLevel.LevelUp(ItemTypeAdd.Plus, 1);
        }
        else
        {
            this.items.Add(item);
            if (item.itemType == ItemType.Equipment)
                this.playerCtrl.Shooter.SetDamaging(item.itemName);
            if (item.itemType == ItemType.Resource)
                this.playerCtrl.Shooter.ShooterLevel.LevelUp(item.ItemTypeAdd, item.count);
        }
     

    }

}
