using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnChickenManager : MySingleton<SpawnChickenManager>,IUsingAllChickenDead
{
    [SerializeField] protected List<Wave> waves;
    public List<Wave> Waves => waves;
    [SerializeField] protected List<RowSO> rows = new List<RowSO>();
    public List<RowSO> Rows => rows;
    [SerializeField] int currentRow = 0;

    [SerializeField] protected int currentWave = 0;
    [SerializeField] protected int spawnCount = 0; 
    [SerializeField] protected int spawnRowCount = 0; 
    [SerializeField] protected float timer=0;
    [SerializeField] protected float delaySpawn= .1f;
    [SerializeField] protected bool isAllChickenDead = false;
 
    protected override void Awake()
    {
        base.Awake();
        if(DataManager.Instance != null)
        {
            this.waves = DataManager.Instance.Mission.waves;
        }
        
        ChickenPoint.Instance.AddPoint(this.rows[0].points);
    }
    protected override void Start()
    {
        ChickenSpawner.Instance.AddListener(this);
    }
    protected virtual void FixedUpdate()
    {
        this.Spawning();
    }
    protected virtual void Spawning()
    {
        if (this.currentWave > this.waves.Count - 1) return;
        if (!this.CountdownTimer() || this.spawnCount >= this.waves[this.currentWave].count) return;
        ChickenSO chickenSO = this.waves[this.currentWave].chickens[0];
   
        Vector3 spawnPos = this.GetFirstPoint();
        Transform obj = ChickenSpawner.Instance.Spawn(chickenSO, spawnPos, Quaternion.identity);
        if (obj == null) return;
        obj.gameObject.SetActive(true);
        this.spawnCount++;


    }
    protected virtual Vector3 GetFirstPoint()
    {
        return this.waves[this.currentWave].rows[currentRow].points[0].point;
    }
    protected virtual bool CountdownTimer()
    {
        this.timer += Time.fixedDeltaTime;
        if (this.timer < this.delaySpawn) return false;
        this.timer = 0f;
        return true;
    }
    public virtual void RowUp(int up)
    {
        this.currentRow += up;
    }

    public void OnAllChickenDead()
    {
        this.isAllChickenDead = true;
        this.spawnCount = 0;
        this.currentWave++;
        if(this.currentWave >= this.waves.Count)
        {
            this.WinGame();
        }
        this.currentRow = 0;
        ChickenPoint.Instance.Row = 0;
        ChickenPoint.Instance.AddPoint(this.rows[this.currentRow].points);
     //   ChickenPointSpawner.Instance.ClearPoint();
    }
    protected virtual void WinGame()
    {
        GameManager.Instance.WinGame();
    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadWaves();
        this.LoadRow();
    }
    protected virtual void LoadWaves()
    {
        if (this.waves.Count > 0) return;
        string path = "Wave/Wave_1";
        this.waves.Add(Resources.Load<Wave>(path));
        Debug.Log(transform.name + ": LoadRow", gameObject);
    }
    protected virtual void LoadRow()
    {
        if (this.rows.Count > 0) return;
        foreach (var row in this.waves[0].rows)
        {
            this.rows.Add(row);
        }
        Debug.Log(transform.name + ": LoadRow", gameObject);
    }
}
