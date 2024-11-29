using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="RowSO",menuName ="RowSO/RowSO")]
public class RowSO : ScriptableObject
{
    public List<PointSO> points;
}
