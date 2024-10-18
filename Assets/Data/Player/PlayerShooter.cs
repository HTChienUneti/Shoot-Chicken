using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : ObjectShooter
{
    protected override void Start()
    {
        base.Start();
        this.prefabName = BulletSpawner.Bullet.Bullet_blue.ToString();
    }
    protected override string GetPrefabName()
    {
        return this.prefabName;
    }
    public virtual void SetBulletPrefab(string prefabName)
    {
        this.prefabName = prefabName;
    }
    protected override Transform GetPrefab()
    {

        Transform newBullet = BulletSpawner.Instance.Spawn(this.prefabName, this.startPos.position, Quaternion.identity);

        return newBullet;
    }
}
