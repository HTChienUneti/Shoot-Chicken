using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Wave", menuName = "Wave")]
public class WaveSO : ScriptableObject
{
    public List<EnemySO> enemys;
    public int count;
}

