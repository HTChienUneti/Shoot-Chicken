using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="ItemPower",menuName ="SO/ItemPower")]
public class ItemPower : ScriptableObject
{
    public Sprite _sprite;
    public PowerCode powerCode;
    public List<Ingredient> ingredients;
    public int power;
    public string damagingName;

}
