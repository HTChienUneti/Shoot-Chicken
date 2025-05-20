using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BulletCtrl : WeaponCtrl
{
    [SerializeField] protected Transform shooter;
    public Transform Shooter
    {
        get { return shooter; }
        set { shooter = value; }
    }
    public virtual void SetModel(Sprite sprite)
    {
        this.model.sprite = sprite;
    }


}
