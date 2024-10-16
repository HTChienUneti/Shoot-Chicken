using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : ObjectShooter
{ 
    protected override string GetPrefabName()
    {
        return BulletSpawner.Bullet_1;
    }
    protected override List<Transform> GetPrefab(int count)
    {
        List<Transform> prefabs = new List<Transform>();
        for(int i = 0; i < count;i++)
        {
            Transform newPrefab = BulletSpawner.Instance.Spawn(this.prefabName, this.startPos.position, Quaternion.identity);
            if (newPrefab == null) break;
             prefabs.Add(newPrefab);
        }
        return prefabs; 
    }
}
