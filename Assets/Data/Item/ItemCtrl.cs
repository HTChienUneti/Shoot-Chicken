using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCtrl : MyMonoBehaviour
{
    [SerializeField] protected ItemDrop itemDrop;
    public ItemDrop ItemDrop => itemDrop;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadItemSO();
    }
    protected virtual void LoadItemSO()
    {
        if (this.itemDrop != null) return;
        string path = "SO/Item/" + transform.name;
        this.itemDrop = Resources.Load<ItemDrop>(path);
        Debug.LogWarning(transform.name + ":  LoadItemSO", gameObject);
    }
}
