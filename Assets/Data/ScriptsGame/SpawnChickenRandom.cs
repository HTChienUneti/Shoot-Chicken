using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnChickenRandom : MyMonoBehaviour
{
    [SerializeField] protected float boundX = 8f;
    [SerializeField] protected float spawnPosY = 5f;
    [SerializeField] protected float timer=0;
    [SerializeField] protected float timerMax= 2f;
    protected virtual void FixedUpdate()
    {
        this.Spawning();
    }
    protected virtual void Spawning()
    {
        if (!this.CountdownTimer()) return;
        Vector3 spawnPos = this.RandomPos();
        string prefabName = ChickenSpawner.chicken_1;
        Transform obj =ChickenSpawner.Instance.Spawn(prefabName, spawnPos, Quaternion.identity);
        if(obj == null) return;
        obj.gameObject.SetActive(true);
    }
    protected virtual Vector3 RandomPos()
    {
        float randomX = Random.Range(-this.boundX, this.boundX);
        return new Vector3(randomX, this.spawnPosY, 0);
    }
    protected virtual bool CountdownTimer()
    {
        this.timer += Time.fixedDeltaTime;
        if (this.timer < this.timerMax) return false;
        this.timer = 0f;
        return true;
    }
}
