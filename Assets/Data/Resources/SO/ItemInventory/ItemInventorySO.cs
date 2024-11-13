using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="ItemInventory",menuName ="SO/ItemInventory")]
[Serializable]
public class ItemInventorySO : ScriptableObject
{
    public ItemProfile itemProfile;
    public int maxStack;
}
