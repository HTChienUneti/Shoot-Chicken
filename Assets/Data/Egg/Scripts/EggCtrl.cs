using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggCtrl : DamagingObjCtrl
{
    [SerializeField] protected ChickenShooter shooter;
    public ChickenShooter Shooter => shooter;
    public virtual void SetShooter(ChickenShooter shooter)
    {
        this.shooter = shooter;
    }

}
