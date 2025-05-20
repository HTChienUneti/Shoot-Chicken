using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Ability", menuName = "SO/Ability")]
public class Ability : ScriptableObject
{
    public List<ItemRequire> requires;
    public Sprite sprite;
}
