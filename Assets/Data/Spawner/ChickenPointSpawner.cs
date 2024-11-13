using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenPointSpawner : Spawner
{
    [Header("ChickenPoint Spawner")]
    private static ChickenPointSpawner _instance;
    public static ChickenPointSpawner Instance => _instance;
    public static string point_1 = "Point_1";

    [SerializeField] protected List<Vector3> points  = new List<Vector3>();
    [SerializeField] protected Vector3 firstPoint = new Vector3(-8, 4.5f, 0);
    [SerializeField] protected float distanceX = 3f;
    [SerializeField] protected float distanceY = 1.5f;
    [SerializeField] protected float bountX = 8f;

    protected override void Awake()
    {
        base.Awake();
        this.LoadSingleton();
    }
    public override Transform Spawn(string prefabName, Vector3 pos, Quaternion rot)
    {
        Transform point =  base.Spawn(prefabName, pos, rot);
        this.points.Add(point.position);
        return point;
    }
    public Vector3 GetPoint()
    {
        Transform point;
        Vector3 pos;
        if(this.points.Count == 0)
        {
            pos = firstPoint;
        }
        else
        {
            pos = this.points[points.Count - 1 ] + new Vector3(this.distanceX,0,0);

            // 
            if (pos.x < this.bountX) goto point;
            pos.x = this.firstPoint.x;
            pos.y -= this.distanceY;
            
        }
        point:  point = this.Spawn(ChickenPointSpawner.point_1, pos, Quaternion.identity);
        return point.position;
    }
    public virtual void ClearPoint()
    {
        this.points.Clear();
    }
    protected virtual void LoadSingleton()
    {
        if (ChickenPointSpawner._instance != null)
        {
            Debug.LogError("There are have more than 1 ChickenPointSpawner");
            return;
        }
        ChickenPointSpawner._instance = this;
    }
}
