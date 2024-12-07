using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenPoint : MySingleton<ChickenPoint>
{
   
    [SerializeField] protected  List<PointSO>points = new List<PointSO>();
    [SerializeField] protected  List<IChickenMoveState >chickens = new List<IChickenMoveState>();
    public List<PointSO> Points=>points;
    int row = 0;
    public int Row
    {
        set => row = value;
        get => row;
    }
    public virtual void AddPoint(List<PointSO> points)
    {
        foreach (var point in points)
        {
            this.points.Add(point);
        }
    }
    public virtual void RemoveLastPoint()
    {
        this.points.RemoveAt(points.Count - 1);
        if(this.points.Count ==2)
        {
            this.points.Clear();
       //     this.points.RemoveAt(0);
            this.row++;
            if (row > SpawnChickenManager.Instance.Rows.Count-1)
            {
                Invoke(nameof(this.TriggChickenMove), 2f);
                return;
            }
      
            this.AddPoint(SpawnChickenManager.Instance.Rows[row].points);
            SpawnChickenManager.Instance.RowUp(1);
        }
    }
    public virtual void AddChicken(IChickenMoveState chickenMoveState)
    {
        this.chickens.Add(chickenMoveState);
    }
    public virtual void RemoveChicken(IChickenMoveState chickenMoveState)
    {
        this.chickens.Remove(chickenMoveState);
    }
    protected virtual void TriggChickenMove()
    {
        foreach(IChickenMoveState chickenMoveState in this.chickens)
        {
            chickenMoveState.MoveAround();
        }
    }
 
}