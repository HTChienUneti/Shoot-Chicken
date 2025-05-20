using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemySO", menuName = "SO/Enemy/EnemySO")]
public class EnemySO : ScriptableObject
{
    public EnemyProfile EnemyProfile;
    public List<ItemDropRate> itemDrop;
    public List<EnemyWeaponSO> weapons;
    public int maxHp = 1;
}
  
