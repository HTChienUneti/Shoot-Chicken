using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="ItemDrop",menuName ="SO/ItemDrop")]
public class ItemDrop : ScriptableObject
{
    public ItemCode itemCode;
    public ItemTypePowerup ItemTypePowerup;
    public ItemType itemType;
    public Sprite sprite;
    public int count;
    public int defaultMaxStack = 10;
}
