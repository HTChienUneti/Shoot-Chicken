using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class EnemyMovement : MyMonoBehaviour
{
    [SerializeField] protected float speed = 5f;
    [SerializeField] protected Vector2 currentpoint;
    [SerializeField] protected float minDisToPoint = 0.1f;
   
}
