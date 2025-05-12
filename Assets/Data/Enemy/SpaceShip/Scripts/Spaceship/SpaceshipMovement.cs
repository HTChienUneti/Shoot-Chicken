using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SpaceshipMovement : EnemyMovement
{
    protected override void OnEnable()
    {
        base.OnEnable();
        currentpoint = WayPointSystem.Instance.GetNextPoint(currentpoint);
        Debug.Log(currentpoint);
        transform.parent.position = currentpoint.position;
    }
    protected override void OnDisable()
    {
        base.OnDisable();
        this.currentpoint = null;
    }
    private void FixedUpdate()
    {

        transform.parent.position = Vector3.MoveTowards(transform.parent.position, currentpoint.position, this.speed * Time.fixedDeltaTime);
        if (Vector3.Distance(transform.parent.position, currentpoint.position) < this.distance)
        {
            currentpoint = WayPointSystem.Instance.GetNextPoint(currentpoint);
        }
    }
}
