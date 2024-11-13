using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagingObjCtrl : MyMonoBehaviour
{
    [SerializeField] protected DamageSender damageSender;
    public DamageSender DamageSender=>damageSender;
     [SerializeField] protected DamagingSO damagingSO;
    public DamagingSO DamagingSO => damagingSO;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadDamageSender();
        this.LoadDamagingSO();
    }
    protected virtual void LoadDamageSender()
    {
        if (this.damageSender != null) return;
        this.damageSender = GetComponentInChildren<DamageSender>();
        Debug.LogWarning(transform.name + " :LoadDamageSender", gameObject);
    }

    protected virtual void LoadDamagingSO()
    {
        if (this.damagingSO != null) return;
        string path = "SO/Damaging/" + transform.name;
        this.damagingSO = Resources.Load<DamagingSO>(path); 
      
        Debug.LogWarning(transform.name + " :LoadDamagingSO", gameObject);
    }
}
