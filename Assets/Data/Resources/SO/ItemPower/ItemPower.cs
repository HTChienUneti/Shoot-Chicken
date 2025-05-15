using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="ItemPower",menuName ="SO/ItemPower")]
public class ItemPower : ScriptableObject
{
    public Profile profile;
    public PowerCode powerCode;
    public int power;
    
}
