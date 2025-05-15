using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "Wave", menuName = "SO/Mission/Wave")]
public class WaveSO : ScriptableObject
{
    public List<EnemySO> enemys;
    public int numberOfEnemy;
    public string wayName;
    public List<PointSO> points;
 
}

