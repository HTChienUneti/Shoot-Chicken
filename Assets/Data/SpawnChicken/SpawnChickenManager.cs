using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnChickenManager : MyMonoBehaviour,IUsingAllChickenDead
{
    [SerializeField] protected List<Wave> waves;
    [SerializeField] protected int currentWave = 0;
    [SerializeField] protected int spawnCount = 0; 
    [SerializeField] protected int currentRespawn = 0; 

    [SerializeField] protected float boundX = 8f;
    [SerializeField] protected float spawnPosY = 5f;
    [SerializeField] protected float timer=0;
    [SerializeField] protected float delaySpawn= .1f;
    [SerializeField] protected bool isAllChickenDead = false;
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
        int index = Random.Range(0, this.waves[currentWave].chickens.Count);
        ChickenSO chickenSO = this.waves[currentWave].chickens[index];
        if (!this.CountdownTimer() || this.spawnCount >= this.waves[currentWave].respawn[currentRespawn]) return;
        Vector3 spawnPos = this.RandomPos();
        Transform obj = ChickenSpawner.Instance.Spawn(chickenSO, spawnPos, Quaternion.identity);
        if (obj == null) return;
        obj.gameObject.SetActive(true);
        this.spawnCount++;
    }
    protected virtual Vector3 RandomPos()
    {
        float randomX = Random.Range(-this.boundX, this.boundX);
        return new Vector3(randomX, this.spawnPosY, 0);
    }
    protected virtual bool CountdownTimer()
    {
        this.timer += Time.fixedDeltaTime;
        if (this.timer < this.delaySpawn) return false;
        this.timer = 0f;
        return true;
    }

    public void OnAllChickenDead()
    {
        this.isAllChickenDead = true;
        this.spawnCount = 0;

        this.currentRespawn++;
        if (this.currentRespawn >= this.waves[this.currentWave].respawn.Count)
        {
            this.currentRespawn = 0;
            this.currentWave++;
        }
            ChickenPointSpawner.Instance.ClearPoint();
    }
}
