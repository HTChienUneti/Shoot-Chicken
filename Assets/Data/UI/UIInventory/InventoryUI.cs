using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MyMonoBehaviour, IUsingInventory
{
    [SerializeField] protected Image image;
    [SerializeField] protected TextMeshProUGUI countText;
    protected override void Start()
    {
        base.Start();
        PlayerCtrl.Instance.Inventory.AddListener(this);
    }   
    public void OnInventoryChanged(List<InventoryItem> items)
    {
        foreach (InventoryItem item in items)
        {

            if (item.itemDrop.itemCode.ToString() !=transform.name) continue;
            this.countText.text = item.stack.ToString();
            break;

        }

    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadSprite();
        this.LoadCountText();

    }
    protected virtual void LoadSprite()
    {
        if (this.image != null) return;
        this.image = GetComponentInChildren<Image>();
        Debug.Log(transform.name + ": LoadSprite", gameObject);
    }
    protected virtual void LoadCountText()
    {
        if (this.countText != null) return;
        this.countText = GetComponentInChildren<TextMeshProUGUI>();
        Debug.Log(transform.name + ": LoadCountText", gameObject);
    }
}

