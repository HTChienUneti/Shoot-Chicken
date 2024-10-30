using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Damaging",menuName ="SO/Damaging")]
public class DamagingSO : ScriptableObject
{
    public Sprite _sprite;
    public DamagingCode damagingCode;
    public int damage;
    public string damagingName;
}
