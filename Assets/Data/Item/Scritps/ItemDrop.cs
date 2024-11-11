using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="ItemDrop",menuName ="SO/ItemDrop")]
public class ItemDrop : ScriptableObject
{
    public ItemProfile itemProfile;
    public ItemTypePowerup ItemTypePowerup;
    public ItemType itemType;
    public int count;
    public int defaultMaxStack = 10;
}
