using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemProfile",menuName = "SO/ItemProfile")]
public class ItemProfile : ScriptableObject
{
    public ItemCode itemCode;
    public Sprite sprite;
    public string itemName;
    public int defaultMaxStack = 10;

}
