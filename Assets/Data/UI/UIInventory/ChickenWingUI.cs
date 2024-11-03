using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenWingUI : InventoryUI, IUsingInventory
{
    protected override void Start()
    {
        base.Start();
        PlayerCtrl.Instance.Inventory.AddListener(this);
    }
    public void OnInventoryChanged(List<InventoryItem> items)
    {
        foreach(InventoryItem item in items)
        {
            if (item.itemDrop.itemCode != ItemCode.ChickenWing) return;
            this.countText.text = item.stack.ToString();
            break;

        }

    }
}
