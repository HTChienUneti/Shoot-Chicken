using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="EnemyProfile",menuName ="SO/Enemy/Profile")]
public class EnemyProfile : ScriptableObject
{
    public EnemyCode enemyCode;
    public Mesh mesh;
    public Material material;
    public string enemyName;
}
