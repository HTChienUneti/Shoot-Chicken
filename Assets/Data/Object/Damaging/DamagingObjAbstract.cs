using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagingObjAbstract : MyMonoBehaviour
{
    [SerializeField] protected DamagingObjCtrl damagingObjCtrl;
    protected override void LoadComponent()
    {
        base.LoadComponent();
 
        this.DamagingObjCtrl();
    }
    protected virtual void DamagingObjCtrl()
    {
        if (this.damagingObjCtrl != null) return;
        this.damagingObjCtrl = transform.parent.GetComponent<DamagingObjCtrl>();
        Debug.Log(transform.name + " :DamagingObjCtrl", gameObject);
    }
}
