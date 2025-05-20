using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Player", menuName ="SO/Player")]
public class PlayerSO : ScriptableObject
{
    public Sprite _sprite;
    public int maxHp = 1;
}
