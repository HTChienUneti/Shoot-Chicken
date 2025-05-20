using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Way : MyMonoBehaviour
{
    [SerializeField] protected List<Point> points = new List<Point>();
    public List<Point> Points
    {
        get { return points; }
        set { this.points = value; }
    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadPoint();
    }
    protected virtual void LoadPoint()
    {
        if (this.points.Count > 0) return;
        this.points= GetComponentsInChildren<Point>().ToList();
        Debug.LogWarning(transform.name + " LoadPoint", gameObject);
    }
}
