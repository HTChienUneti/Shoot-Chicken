using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WeaponSO : ScriptableObject
{
    public Sprite _sprite;
    public int damage;
    public string _name;
    public int maxHp = 1;
    public List<EnemyWeaponSO> weapons;
    public List<ItemDropRate> itemDrop;
}
