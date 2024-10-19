using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="ItemSO",menuName ="SO/ItemSO")]
public class ItemDrop : ScriptableObject
{
    public ItemCode itemCode;
    public ItemType itemType;
    public ItemTypeAdd ItemTypeAdd;
    public string itemName;
    public Sprite sprite;
    public int count;
}
