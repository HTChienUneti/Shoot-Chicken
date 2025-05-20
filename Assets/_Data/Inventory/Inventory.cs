using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class Inventory : PlayerAbstract
{
    [SerializeField] protected List<ItemInventory> items;
    public List<ItemInventory> Items=>items;
    protected List<IUsingInventory> listeners = new List<IUsingInventory>();
    public event EventHandler<OnInventoryChangedEventArgs> OnInventoryChanged;
    public class OnInventoryChangedEventArgs: EventArgs
    {
        public ItemInventory Item;  
    }
    public virtual void AddItem(Profile itemProfile, int count)
    {
        ItemInventory inventoryItem = this.GetItemFromInventoryByProfile(itemProfile);
        //if inventory haven't have this item yet
        if(inventoryItem == null)
        {
            inventoryItem= this.CreateItemInventory(itemProfile,count);
            inventoryItem.stack = 0;
            this.items.Add(inventoryItem);
        }
        this.AddItem(inventoryItem, count);
    }
    public virtual void AddItem(ItemInventory itemInventory, int count)
    {
        itemInventory.stack += count;
        if (itemInventory.stack > itemInventory.itemSO.maxStack)
        {
            itemInventory.stack = itemInventory.itemSO.maxStack;
        }
        this.InventoryChanged(itemInventory);
        this.DistributeItem(itemInventory);
    }
    protected virtual void DistributeItem(ItemInventory itemInventory)
    {
        this.playerCtrl.Shooter.ChangeWeaponManager.ChangeWeaponByItemProfile(itemInventory.itemSO.itemProfile);
    }
    protected virtual ItemInventory CreateItemInventory(Profile itemProfile, int count)
    {
        ItemInventorySO itemInventorySO = this.GetItemInventorySOByProfile(itemProfile);

        ItemInventory newItem = new ItemInventory()
        {
            itemSO = itemInventorySO,
            stack = count,
            maxStack = itemInventorySO.maxStack,    
        };

        return newItem;
    }
    protected virtual ItemInventorySO GetItemInventorySOByProfile(Profile itemProfile)
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

    public virtual void RemoveItem(ItemInventorySO itemSO, int count)
    {
        ItemInventory itemInventory = this.GetItemFromListBySO(itemSO);
        this.RemoveItem(itemInventory, count);
    }

    public virtual void RemoveItem(ItemInventory item, int count)
    {
        item.stack -= count;
        this.InventoryChanged(item);
        if (item.stack > 0) return;
        this.items.Remove(item);
    }
    protected virtual ItemInventory GetItemFromListBySO(ItemInventorySO itemSO)
    {
        foreach (ItemInventory item in this.items)
        {
            if (item.itemSO != itemSO) continue;
            return item;
        }
        return null;
    }
    protected virtual ItemInventory GetItemFromListByCode(Id itemCode)
    {
        foreach (ItemInventory itemInv in this.items)
        {
            if (itemInv.itemSO.itemProfile.id != itemCode) continue;
            return itemInv;
        }
        return null;
    }
    protected virtual ItemInventory GetItemFromInventoryByProfile(Profile itemProfile)
    {
        foreach (ItemInventory itemInv in this.items)
        {
            if (itemInv.itemSO.itemProfile != itemProfile) continue;
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
    public void InventoryChanged(ItemInventory itemInventory)
    {
        this.OnInventoryChanged?.Invoke(this, new OnInventoryChangedEventArgs()
        {
            Item = itemInventory
        });
    }
}
