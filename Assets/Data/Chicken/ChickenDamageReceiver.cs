using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenDamageReceiver : DamageReceiver
{
    protected override void OnDead()
    {
        ChickenSpawner.Instance.Despawn(transform.parent);
    }
}
