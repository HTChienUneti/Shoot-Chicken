using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Mission",menuName ="Mission/Mission")]
public class MissionSO : ScriptableObject
{
    public List<Wave> waves;
    public Sprite map;

}
