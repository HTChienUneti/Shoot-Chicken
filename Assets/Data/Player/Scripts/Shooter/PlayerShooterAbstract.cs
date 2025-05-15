using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerShooterAbstract : MyMonoBehaviour
{
    [Header("PlayerShooter Abstract")]
    [SerializeField]protected  PlayerShooter playerShooter;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadPlayerShooterAbtract();
    }
    protected virtual void LoadPlayerShooterAbtract()
    {
        if (this.playerShooter != null) return;
        this.playerShooter = this.GetComponentInParent<PlayerShooter>();
        Debug.Log(transform.name + ": LoadPlayerCtrl", gameObject);
    }
    

}
