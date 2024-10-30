using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : ObjectShooter
{
    [SerializeField] protected bool autoShoot = false;
    protected override void Shooting()
    {
        if(!this.autoShoot) 
            if (InputManager.Instance.Fire_1 == 0) return;
        base.Shooting();
    }   
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
