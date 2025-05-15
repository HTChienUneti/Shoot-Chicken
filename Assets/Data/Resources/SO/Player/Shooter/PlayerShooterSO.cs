using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="PlayerShooter",menuName ="SO/PlayerShoooter")]
public class PlayerShooterSO : ScriptableObject
{
    public List<PlayerWeaponSO> weapons;
    public List<ItemPower> powers;
}
