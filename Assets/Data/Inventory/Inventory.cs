using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class Inventory : PlayerAbstract
{
    [SerializeField] protected List<ItemInventory> items;
    public List<ItemInventory> Items=>items;
    protected List<IUsingInventory> listeners = new List<IUsingInventory>();
    protected override void Start()
    {
        base.Start();
        // InvokeRepeating(nameof(this.Test),5,5);
    }
    //public virtual bool Contains(string itemName )
    //{
    //    foreach( InventoryItem item in items )
    //    {
    //        if (item.itemDrop.itemCode.ToString() != itemName) continue;
    //        return true;
    //    }
    //    return false;
    //}
    public virtual ItemInventory GetItemInventory(ItemProfile itemProfile)
    {
        foreach (ItemInventory item in items)
        {
            if (item.item.itemProfile != itemProfile) continue;
            return item;
        }
        return null;
    }
    public virtual ItemInventory GetItemInventory(ItemInventory itemInventory)
    {
        foreach (ItemInventory item in items)
        {
            if (item != itemInventory) continue;
            return item;
        }
        return null;
    }
    protected virtual void Test()
    {
        //this.RemoveItem(ItemCode.ChickenWing, 1);
    }
    //public virtual void AddItem(ItemCode itemCode, int count)
    //{
    //    ItemInventory inventoryItem = this.GetItemFromListByCode(itemCode);
    //    this.AddItem(inventoryItem, count);
    //}
    public virtual void AddItem(ItemProfile itemProfile, int count)
    {
        ItemInventory inventoryItem = this.GetItemFromListByProfile(itemProfile);
        if(inventoryItem == null)
        {
            inventoryItem= this.CreateItemInventory(itemProfile,count);
            inventoryItem.stack = 0;
            this.items.Add(inventoryItem);
        }
        this.AddItem(inventoryItem, count);
    }
    //public virtual void AddItem(InventoryItem inventoryItem, int count)
    //{
    //    this.AddItem(inventoryItem, count);    
    //}
    public virtual void AddItem(ItemInventory itemInventory, int count)
    {
        itemInventory.stack += count;
        if (itemInventory.stack > itemInventory.item.maxStack)
        {
            itemInventory.stack = itemInventory.item.maxStack;
        }
     
        this.OnInventoryChanged();
    }
    protected virtual ItemInventory GetItemFromList(ItemInventory itemInventory)
    {
        foreach (ItemInventory itemInv in this.items)
        {
            if (itemInv != itemInventory) continue;
            return itemInv;
        }
        return null;
    }
    protected virtual ItemInventory CreateItemInventory(ItemProfile itemProfile, int count)
    {
        ItemInventorySO itemInventorySO = this.GetItemInventorySOByProfile(itemProfile);

        ItemInventory newItem = new ItemInventory()
        {
            item = itemInventorySO,
            stack = count,
            maxStack = itemInventorySO.maxStack,    
        };

        return newItem;
    }
    protected virtual ItemInventorySO GetItemInventorySOByProfile(ItemProfile itemProfile)
    {
        string path = "SO/ItemInventory/";
        ItemInventorySO[] itemSO = Resources.LoadAll<ItemInventorySO>(path);    
        foreach(ItemInventorySO itemInventorySO in itemSO)
        {
            if(itemInventorySO.itemProfile != itemProfile) continue;
            return itemInventorySO;
        }
        return null;    
    }
    public virtual void RemoveItem(string itemName, int count)
    {
        ItemCode itemCode = Parse.StringToItemCode(itemName);
        this.RemoveItem(itemCode, count);
    }
    public virtual void RemoveItem(ItemCode itemCode, int count)
    {
       ItemInventory inventoryItem = this.GetItemFromListByCode(itemCode);
        if (inventoryItem == null) return;
       this.RemoveItem(inventoryItem, count);
    }
    public virtual void RemoveItem(ItemProfile itemProfile, int count)
    {
        ItemInventory inventoryItem = this.GetItemFromListByProfile(itemProfile);
        if (inventoryItem == null) return;
        this.RemoveItem(inventoryItem, count);  
    }
    public virtual void RemoveItem(ItemInventory item, int count)
    {
        item.stack -= count;
        this.OnInventoryChanged();
        if (item.stack > 0) return;
        this.items.Remove(item);
    }
    protected virtual ItemInventory GetItemFromListByCode(ItemCode itemCode)
    {
        foreach (ItemInventory itemInv in this.items)
        {
            if (itemInv.item.itemProfile.itemCode != itemCode) continue;
            return itemInv;
        }
        return null;
    }
    protected virtual ItemInventory GetItemFromListByProfile(ItemProfile itemProfile)
    {
        foreach (ItemInventory itemInv in this.items)
        {
            if (itemInv.item.itemProfile != itemProfile) continue;
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
