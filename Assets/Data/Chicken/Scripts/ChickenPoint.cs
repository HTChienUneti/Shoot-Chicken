using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenPoint : MyMonoBehaviour
{
    static private ChickenPoint _instance;
    static public ChickenPoint Instance=> _instance;
    [SerializeField] protected List<Point> poins = new List<Point>();
    public List<Point> Points=>poins;

    protected override void Awake()
    {
        base.Awake();
        this.LoadSingleton();
    }
    protected virtual void LoadSingleton()
    {
        if(ChickenPoint.Instance!=null)
        {
            Debug.LogError("There are already have a ChickenPoint", gameObject);
            return;
        }
        ChickenPoint._instance = this;   

    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadPoint();
    }
    protected virtual void LoadPoint()
    {
        if (poins.Count > 0) return;
        foreach(Transform child in transform)
        {

            this.poins.Add(child.GetComponent<Point>());
        }
        Debug.LogWarning(transform.name + ": LoadPoint", gameObject);
    }
 
}