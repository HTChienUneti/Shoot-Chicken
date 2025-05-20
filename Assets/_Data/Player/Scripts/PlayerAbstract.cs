using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerAbstract : MyMonoBehaviour
{
    [Header("Player Abstcract")]
    [SerializeField]protected  PlayerCtrl playerCtrl;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadPlayerCtrl();
    }
    protected virtual void LoadPlayerCtrl()
    {
        if (this.playerCtrl != null) return;
        this.playerCtrl = this.GetPlayCtrlComponent();
        Debug.Log(transform.name + ": LoadPlayerCtrl", gameObject);
    }
    protected virtual PlayerCtrl GetPlayCtrlComponent()
    {
        return transform.parent.GetComponent<PlayerCtrl>();
    }

}
