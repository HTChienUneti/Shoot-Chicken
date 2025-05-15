using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.Collections.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnEnemyManager : MySingleton<SpawnEnemyManager>
{
    [SerializeField] protected List<WaveSO> waves = new List<WaveSO>();
    public List<WaveSO> Waves => waves;
    [SerializeField] protected int mission;
    public int Mission => mission;  

    [SerializeField] protected int currentWave = 0;
    public int CurrentWave => currentWave;
    [SerializeField] protected int spawnCount = 0; 
    [SerializeField] protected float timer=0;
    [SerializeField] protected float delaySpawn= .3f;
    [SerializeField] protected bool isAllEnemyDead = false;
    [SerializeField] protected bool isSpawning = false;
    public event EventHandler<OnWaveChangeEventArgs> OnWaveChanged;
    public class OnWaveChangeEventArgs: EventArgs
    {
        public int wave;
    }
    protected override void Awake()
    {
        base.Awake();
        if(MissionDataManager.Instance != null)
        {
            this.waves = MissionDataManager.Instance.Mission.waves;
            this.mission = MissionDataManager.Instance.Mission.missionIndex;
        }
      
    }
    protected override void Start()
    {
     
        EnemySpawner.Instance.OnAllChikenDead += ChickenSpawner_OnAllChikenDead;
         PlayingGameState.Instance.OnEnterState += ChickenActiveState_OnEnterState;
        PlayingGameState.Instance.OnExitState += ChickenActiveState_OnExitState;
    }

    private void ChickenSpawner_OnAllChikenDead(object sender, EventArgs e)
    {
        this.OnAllEnemyDead();
    }

    private void ChickenActiveState_OnEnterState(object sender, System.EventArgs e)
    {
       this.isSpawning = true;  
    }
    private void ChickenActiveState_OnExitState(object sender, System.EventArgs e)
    {
       this.isSpawning = false;  
    }

    protected virtual void FixedUpdate()
    {
        this.Spawning();
    }
    protected virtual void Spawning()
    {
        if (!this.isSpawning) return;
        if (this.currentWave > this.waves.Count - 1) return;
        if (!this.CountdownTimer() || this.spawnCount >= this.waves[this.currentWave].count) return;
        EnemySO enemySO = this.waves[this.currentWave].enemys[0];
        Transform obj = EnemySpawner.Instance.Spawn(enemySO, Vector3.zero, Quaternion.identity);
        if (obj == null) return;
        
        obj.gameObject.SetActive(true);
        this.spawnCount++;


    }
    protected virtual bool CountdownTimer()
    {
        this.timer += Time.fixedDeltaTime;
        if (this.timer < this.delaySpawn) return false;
        this.timer = 0f;
        return true;
    }

    public void OnAllEnemyDead()
    {
        this.isAllEnemyDead = true;
        this.spawnCount = 0;
        this.currentWave++;
        WayPointSystem.Instance.CurrentWayIndex++;
        if (this.currentWave >= this.waves.Count)
        {
            GameManager.Instance.WinGame();
            return;
        }
        this.OnWaveChanged?.Invoke(this, new OnWaveChangeEventArgs
        {
            wave = this.currentWave,
        });
        GameManager.Instance.WarningGame();
     
    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadWaves(); 
    }
    protected virtual void LoadWaves()
    {
        if (this.waves.Count > 0) return;
        string path = "Wave/Wave_1";
        this.waves.Add(Resources.Load<WaveSO>(path));
        Debug.Log(transform.name + ": LoadRow", gameObject);
    }
}
