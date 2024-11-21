using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamagingable
{
    public DamageSender DamageSender { get; }

    public void TakeDamage(DamageReceiver damageReceiver);
}
