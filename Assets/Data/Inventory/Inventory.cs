using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] protected List<ItemDrop> items;
    public virtual void AddItem(ItemDrop item)
    {
        this.items.Add(item);
    }
}
