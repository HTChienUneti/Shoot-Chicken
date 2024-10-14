using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenDamageReceiver : DamageReceiver
{   
    protected override void OnDead()
    {
        ChickenSpawner.Instance.Despawn(transform.parent);
        base.OnDead();
    }
    protected override void ResetValue()
    {
        this.Collider.radius = .4f;
        this.hpMax = 1;
        base.ResetValue();

    }
    protected override void CreateVFXDead()
    {
        string prefabName = VFXSpawner.boom_1;
        Transform prefab = VFXSpawner.Instance.Spawn(prefabName,transform.position,transform.rotation);
        if (prefab == null) return;
        prefab.gameObject.SetActive(true);
    }
}
