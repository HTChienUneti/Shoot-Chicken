using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BosWayPointSystem : MySingleton<BosWayPointSystem>
{
    public Transform GetNextPoint(Transform currentPoint)
    {
        if(currentPoint == null)
        {
            return transform.GetChild(0);
        }
        else if(currentPoint.GetSiblingIndex() == transform.childCount - 1)
        {
            return transform.GetChild(1);
        }
        else
        {
            return transform.GetChild(currentPoint.GetSiblingIndex()+1);
        }
    }
    public void SetFirstPoint()
    {
        int childCount = transform.childCount;
        for(int i=1;i<childCount;i++)
        {
            if (i % 2 == 0) continue;
            Transform target = transform.GetChild(i);
            transform.GetChild(i-1).SetSiblingIndex(i);
            target.SetSiblingIndex(i-1);
        }
   
    }
}