using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : ObjectShooter
{ 
    protected override string GetPrefabName()
    {
        return BulletSpawner.Bullet_1;
    }
    protected override Transform GetPrefab()
    {
        return BulletSpawner.Instance.Spawn(this.prefabName, this.startPos.position, Quaternion.identity);
    }
}
