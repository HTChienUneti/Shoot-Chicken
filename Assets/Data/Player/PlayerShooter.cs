using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : ObjectShooter
{
    
    protected override Transform GetPrefab()
    {
        Transform newBullet = BulletSpawner.Instance.Spawn(this.damagingSO, this.startPos.position, Quaternion.identity);
        return newBullet;
    }

    protected override string GetDamagingName()
    {
        return "Bullet_Blue";
    }
}
