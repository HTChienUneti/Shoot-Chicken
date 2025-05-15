using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WeaponSO : ScriptableObject
{
    public Profile itemProfile;
    public int damage;
    public int maxHp = 1;
    public List<EnemyWeaponSO> weapons;
    public List<ItemDropRate> itemDrop;
}
