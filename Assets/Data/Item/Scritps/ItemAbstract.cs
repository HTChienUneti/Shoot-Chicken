using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAbstract : MyMonoBehaviour
{
    [Header("Item Abstract")]
    [SerializeField] protected ItemCtrl itemCtrl;
    public ItemCtrl ItemCtrl=> itemCtrl;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadItemCtrl();
    }
    protected virtual void LoadItemCtrl()
    {
        if (this.itemCtrl != null) return;
        this.itemCtrl = transform.parent.GetComponent<ItemCtrl>();
        Debug.Log(transform.name + ": LoadItemCtrl", gameObject);
    }

}
