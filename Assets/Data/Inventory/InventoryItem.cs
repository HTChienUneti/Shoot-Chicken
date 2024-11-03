using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class InventoryItem
{
    public ItemDrop itemDrop;
    public int stack;
    public int stackMax = 10;

}
