using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCtrl : MyMonoBehaviour
{
    [SerializeField] protected ItemDrop itemDrop;
    public ItemDrop ItemDrop => itemDrop;
    [SerializeField] protected Transform model;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadItemSO();
        this.LoadModel();
    }
    protected virtual void LoadModel()
    {
        if (this.model != null) return;

        this.model = transform.Find("Model");
        this.model.GetComponent<SpriteRenderer>().sprite = this.itemDrop.itemProfile.sprite;
        Debug.LogWarning(transform.name + ":  LoadModel", gameObject);
    }
    protected virtual void LoadItemSO()
    {
        if (this.itemDrop != null) return;
        string path = "SO/ItemDrop/" + transform.name;
        this.itemDrop = Resources.Load<ItemDrop>(path);
        Debug.LogWarning(transform.name + ":  LoadItemSO", gameObject);
    }
}
