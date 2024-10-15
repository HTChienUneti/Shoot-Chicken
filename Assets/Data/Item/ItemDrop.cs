using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="ItemSO",menuName ="SO/ItemSO")]
public class ItemDrop : ScriptableObject
{
    public ItemCode itemCode;
    public Sprite sprite;
}
