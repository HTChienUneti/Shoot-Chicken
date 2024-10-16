using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSender : MyMonoBehaviour
{

    [SerializeField] protected int damage =1;
    public virtual void Send(DamageReceiver damageReceiver)
    {
        damageReceiver.ReduceHp(this.damage);
    }
}

