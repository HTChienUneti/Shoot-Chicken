using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Weapon", menuName = "SO/PlayerWeaponSO")]

public class PlayerWeaponSO : WeaponSO
{
    public bool isDefault;
    public float timeUse;
    public KeyCode keycode;
}
