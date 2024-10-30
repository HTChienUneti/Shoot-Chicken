using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnChicken : MyMonoBehaviour,IUsingAllChickenDead
{
    [SerializeField] protected float boundX = 8f;
    [SerializeField] protected float spawnPosY = 5f;
    [SerializeField] protected float timer=0;
    [SerializeField] protected float timeMax= .1f;
    [SerializeField] protected int spawnCount = 0;
    [SerializeField] protected int spawnMax = 6;
    [SerializeField] protected bool isAllChickenDead = false;
    [SerializeField] protected int wave = 1;
    protected override void Start()
    {
        ChickenSpawner.Instance.AddListener(this);
    }
    protected virtual void ReduceMax()
    {
        this.timeMax -= .2f;
    }
    protected virtual void FixedUpdate()
    {
        this.Spawning();
    }
    protected virtual void Spawning()
    {
        if (!this.CountdownTimer() || this.spawnCount >= this.spawnMax) return;
        Vector3 spawnPos = this.RandomPos();
        string prefabName = ChickenSpawner.chicken_1;
        Transform obj = ChickenSpawner.Instance.Spawn(prefabName, spawnPos, Quaternion.identity);
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
        if (this.timer < this.timeMax) return false;
        this.timer = 0f;
        return true;
    }

    public void OnAllChickenDead()
    {
        this.isAllChickenDead = true;
        this.spawnCount = 0;

        this.wave++;
    }
}
