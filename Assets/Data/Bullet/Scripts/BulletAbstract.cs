using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BulletAbstract : MyMonoBehaviour
{
    [Header("Bullet Abstract")]
    [SerializeField] protected BulletCtrl bulletCtrl;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadDamageSender();
    }
    protected virtual void LoadDamageSender()
    {
        if (this.bulletCtrl != null) return;
        this.bulletCtrl =transform.parent.GetComponent<BulletCtrl>();
        Debug.LogWarning(transform.name + ": LoadDamageSender", gameObject);
    }
}
