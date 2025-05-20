using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SpaceshipMovement : EnemyMovement
{
    protected override void OnEnable()
    {
        base.OnEnable();
        currentpoint = EnemyMovementManager.Instance.GetNextPoint(currentpoint);
        Debug.Log(currentpoint);
        transform.parent.position = currentpoint;
    }
    protected  override  void OnDisable()
    {
        this.currentpoint = Vector2.zero;
    }
    private void FixedUpdate()
    {

        transform.parent.position = Vector2.MoveTowards(transform.parent.position, currentpoint, this.speed * Time.fixedDeltaTime);
        if (Vector2.Distance(transform.parent.position, currentpoint) < this.minDisToPoint)
        {
            currentpoint = EnemyMovementManager.Instance.GetNextPoint(currentpoint);
        }
    }
}
