using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Wave", menuName = "Wave")]
public class Wave : ScriptableObject
{
    public List<ChickenSO> chickens;
    public int count;
    public List<RowSO> rows;
}

