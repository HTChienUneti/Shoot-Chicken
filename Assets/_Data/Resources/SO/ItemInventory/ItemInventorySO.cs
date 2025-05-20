using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="ItemInventory",menuName ="SO/ItemInventory")]
[Serializable]
public class ItemInventorySO : ScriptableObject
{
    public Profile itemProfile;
    public int maxStack;
}
