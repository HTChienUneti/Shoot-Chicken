using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WayPointSystem : MySingleton<WayPointSystem>
{
    [SerializeField] protected List<Way> ways = new List<Way>();
    [SerializeField] protected int currentWayIndex = 0;
    public int CurrentWayIndex
    {
        get { return this.currentWayIndex; }
        set { this.currentWayIndex = value; }
    }
    public Transform GetNextPoint(Transform currentPoint)
    {
        if(currentPoint == null)
        {
            return this.ways[CurrentWayIndex].Points[0].transform;
        }
        else if(currentPoint.GetSiblingIndex() == this.ways[this.CurrentWayIndex].Points.Count-1)
        {
            return this.ways[this.CurrentWayIndex].Points[0].transform;
        }
        else
        {
            return this.ways[this.CurrentWayIndex].Points[currentPoint.GetSiblingIndex() + 1].transform;
        }
        //if(currentPoint == null)
        //{
        //    return transform.GetChild(0);
        //}
        //else if(currentPoint.GetSiblingIndex() == transform.childCount - 1)
        //{
        //    return transform.GetChild(0);
        //}
        //else
        //{
        //    return transform.GetChild(currentPoint.GetSiblingIndex()+1);
        //}
    }
    
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadWays();
    }
    protected void LoadWays()
    {
        if (this.ways.Count > 0) return;
        this.ways = GetComponentsInChildren<Way>().ToList();
        Debug.LogWarning(transform.name + " LoadWays", gameObject);
    }
}