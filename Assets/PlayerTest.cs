using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTest : MonoBehaviour
{
    Transform currentpoint;
    public WayPointSystem wayPointSystem;
    private void Start()
    {
        currentpoint = wayPointSystem.GetNextPoint(currentpoint);
        transform.parent.position = currentpoint.position;
    }
    private void Update()
    {
     
        transform.parent.position = Vector3.MoveTowards(transform.parent.position, currentpoint.position, 5f * Time.deltaTime);
        if (Vector3.Distance(transform.parent.position, currentpoint.position) < 0.1f)
        {
            currentpoint = wayPointSystem.GetNextPoint(currentpoint);
        }
    }
}
