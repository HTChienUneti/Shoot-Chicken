using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] protected List<ItemDrop> items;
    public virtual void AddItem(ItemDrop item)
    {
        if (this.items.Contains(item)) return;
        this.items.Add(item);
    }
}
