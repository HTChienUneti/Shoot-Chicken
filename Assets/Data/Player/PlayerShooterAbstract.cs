using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class PlayerShooterAbstract : MyMonoBehaviour
{
    [SerializeField] protected PlayerShooter playerShooter;
    [SerializeField] protected PlayerShooter ShooterplayerShooter;
    //protected virtual void LoadPlayerCtrl()
    //{
    //    if (this.playerCtrl != null) return;
    //    this.playerCtrl = transform.parent.GetComponent<PlayerCtrl>();
    //    Debug.LogWarning(transform.name + ": LoadPlayerCtrl", gameObject);
    //}

}
