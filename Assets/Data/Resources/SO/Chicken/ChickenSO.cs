using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ChickenSO", menuName = "SO/ChickenSO")]
public class ChickenSO : ScriptableObject
{
    public ChickenCode ChickenCode;
    public DamagingSO damaging;
    public Sprite _sprite;
    public string chickenName;
    public List<ItemDropRate> itemDrop;
    public int maxHp = 1;
}
  
