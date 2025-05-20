using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyMovementManager : MySingleton<EnemyMovementManager>
{
    [SerializeField] protected List<WaveSO> waves = new List<WaveSO>();
    [SerializeField] protected int currentWayIndex = 0;
    public int CurrentWaveIndex
    {
        get { return this.currentWayIndex; }
        set { this.currentWayIndex = value; }
    }
    protected override void Start()
    {
        base.Start();
        this.waves = new List<WaveSO>(MissionDataManager.Instance.Mission.waves);
    }
    public Vector2 GetNextPoint(Vector2 currentPoint)
    {
        int n = this.waves[this.CurrentWaveIndex].points.Count;
        int currentIndex = -1;
        for(int i = 0;i<this.waves[this.currentWayIndex].points.Count;i++)
        {
            if (this.waves[this.currentWayIndex].points[i].position != currentPoint) continue;
            currentIndex = i;
            break;
        }
        
        if (currentIndex == -1)
        {
            return this.waves[CurrentWaveIndex].points[0].position;
        }
        else if(currentIndex==n-1)
        {
            return this.waves[this.CurrentWaveIndex].points[0].position;
        }
        else
        {
            return this.waves[this.CurrentWaveIndex].points[currentIndex+1].position;
        }
    }

}