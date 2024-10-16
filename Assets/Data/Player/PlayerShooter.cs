using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : ObjectShooter
{
    Vector3 bulletPos;
    protected override string GetPrefabName()
    {
        return BulletSpawner.Bullet_1;
    }
    protected override List<Transform> GetPrefab(int count)
    {
      
        List<Transform> bullets = new List<Transform>();
        float addDis =0;
        for (int i = 0; i < count;i++)
        {
            if (count >1)
            {
                addDis = i > 0 ? 0.5f : -0.5f;
            }   
            this.bulletPos = this.startPos.position + new Vector3(addDis, 0, 0);
            Transform newBullet = BulletSpawner.Instance.Spawn(this.prefabName, this.startPos.position, Quaternion.identity);
            newBullet.position = this.bulletPos;
            if (newBullet == null) break;
            bullets.Add(newBullet);
        }
        return bullets; 
    }
}
