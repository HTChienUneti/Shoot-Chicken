using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : ImageTextBase, IUsingInventory
{
    [SerializeField] protected ItemInventorySO itemInventory;
    protected override void Start()
    {
        base.Start();
        PlayerCtrl.Instance.Inventory.AddListener(this);
    }   
    public void OnInventoryChanged(List<ItemInventory> items)
    {
        foreach (ItemInventory item in items)
        {
            if (item.itemSO != itemInventory) continue;
            this.countText.text = item.stack.ToString();
            break;
        }

    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadItemInventory();

    }

    protected virtual void LoadItemInventory()
    {
        if (this.itemInventory != null) return;
        string path = "SO/ItemInventory/" + transform.name;
        Debug.Log(path);
        this.itemInventory = Resources.Load<ItemInventorySO>(path);
        Debug.Log(transform.name + ": LoadItemInventory", gameObject);
    }
}

