using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Mission",menuName ="Mission/Mission")]
public class MissionSO : ScriptableObject
{
    public int missionIndex;
    public List<WaveSO> waves;
    public Sprite map;

}
