using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootableObjAbstract : MyMonoBehaviour
{
    [SerializeField] protected ShootedableObjCtrl shootableObjCtrl;

    protected override void LoadComponent()
    {
        base.LoadComponent();
 
        this.LoadShootableObjCtrl();
    }
    protected virtual void LoadShootableObjCtrl()
    {
        if (this.shootableObjCtrl != null) return;
        this.shootableObjCtrl = transform.parent.GetComponent<ShootedableObjCtrl>();
        Debug.Log(transform.name + " :LoadShootableObjCtrl", gameObject);
    }
}
