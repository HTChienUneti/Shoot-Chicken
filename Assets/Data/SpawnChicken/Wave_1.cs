using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave_1 : SpawnChicken
{
 
    protected override void Spawning()
    {
        if (!this.CountdownTimer() || this.spawnCount >= this.spawnMax) return;
        Vector3 spawnPos = this.RandomPos();
        string prefabName = ChickenSpawner.chicken_1;
        Transform obj = ChickenSpawner.Instance.Spawn(prefabName, spawnPos, Quaternion.identity);
        if (obj == null) return;
        obj.gameObject.SetActive(true);
        this.spawnCount++;  
    }
}
