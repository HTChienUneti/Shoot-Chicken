using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class Inventory : PlayerAbstract
{
    [SerializeField] protected List<InventoryItem> items;
    protected List<IUsingInventory> listeners = new List<IUsingInventory>();
    protected override void Start()
    {
        base.Start();
        // InvokeRepeating(nameof(this.Test),5,5);
    }
    public virtual bool Contains(string itemName )
    {
        foreach( InventoryItem item in items )
        {
            if (item.itemDrop.itemCode.ToString() != itemName) continue;
            return true;
        }
        return false;
    }
    protected virtual void Test()
    {
        this.RemoveItem(ItemCode.ChickenWing, 1);
    }
    public virtual void AddItem(ItemCode itemCode, int count)
    {
        InventoryItem inventoryItem = this.GetItemFromListByCode(itemCode);
        this.AddItem(inventoryItem, count);
    }
    public virtual void AddItem(InventoryItem inventoryItem, int count)
    {
        this.AddItem(inventoryItem.itemDrop, count);    
    }
    public virtual void AddItem(ItemDrop item, int count)
    {
        InventoryItem inventoryItem = this.GetItemFromList(item);
        if (inventoryItem == null)
        {
            inventoryItem = this.CreateInventoryItem(item, count);
            this.items.Add(inventoryItem);
        }
        else
        {
            inventoryItem.itemDrop = item;
            inventoryItem.stack += count;
        }

        if (inventoryItem.stack > inventoryItem.stackMax)
        {
            inventoryItem.stack = inventoryItem.stackMax;
        }

        this.OnInventoryChanged();
    }
    protected virtual InventoryItem GetItemFromList(ItemDrop item)
    {
        foreach (InventoryItem itemInv in this.items)
        {
            if (itemInv.itemDrop != item) continue;
            return itemInv;
        }
        return null;
    }
    protected virtual InventoryItem CreateInventoryItem(ItemDrop item, int count)
    {
        InventoryItem inventoryItem = new InventoryItem()
        {
            itemDrop = item,
            stack = count
        };

        return inventoryItem;
    }
    public virtual void RemoveItem(string itemName, int count)
    {
        ItemCode itemCode = Parse.StringToItemCode(itemName);
        this.RemoveItem(itemCode, count);
    }
    public virtual void RemoveItem(ItemCode itemCode, int count)
    {
       InventoryItem inventoryItem = this.GetItemFromListByCode(itemCode);
        if (inventoryItem == null) return;
       this.RemoveItem(inventoryItem, count);
    }
    public virtual void RemoveItem(InventoryItem item, int count)
    {
   
        item.stack -= count;
        this.OnInventoryChanged();
        if (item.stack > 0) return;
        this.items.Remove(item);
    }
    protected virtual InventoryItem GetItemFromListByCode(ItemCode itemCode)
    {
        foreach (InventoryItem itemInv in this.items)
        {
            if (itemInv.itemDrop.itemCode != itemCode) continue;
            return itemInv;
        }
        return null;
    }
  
    public virtual void AddListener(IUsingInventory listener)
    {
        this.listeners.Add(listener);
    }
    public virtual void RemoveListener(IUsingInventory listener)
    {
        this.listeners.Remove(listener);
    }

    public void OnInventoryChanged()
    {

        foreach (IUsingInventory listener in this.listeners)
        {
            listener.OnInventoryChanged(this.items);
        }
       
    }
}
