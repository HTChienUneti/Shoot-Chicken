using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="ChickenSO",menuName = "SO/ChickenSO")]
public class ChickenSO : ScriptableObject
{
    public ChickenCode ChickenCode;
    public string chickenName;
    public ItemDrop itemDrop;
}
