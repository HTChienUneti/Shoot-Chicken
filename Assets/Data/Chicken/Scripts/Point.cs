using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Point:MyMonoBehaviour
{
    public Vector3 point;
    public bool isUsed;
    public Point(Vector3 point, bool isUsed)
    {
        this.point = point;
        this.isUsed = isUsed;
    }


    protected override void Start()
    {
        base.Start();
        this.point = transform.position;
    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadPoint();
    }
    protected virtual void LoadPoint()
    {
        if (this.point != Vector3.zero) return;
        this.point = transform.position;
        Debug.LogWarning(transform.name + ": LoadPoint", gameObject);
    }
}
