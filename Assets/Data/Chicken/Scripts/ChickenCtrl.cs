using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenCtrl : ShootedableObjCtrl
{
    [SerializeField] protected ChickenMovement chickenMovement;
    public ChickenMovement ChickenMovement => chickenMovement;
    [SerializeField] protected ChickenSO chickenSO;
    public ChickenSO ChickenSO=> chickenSO;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadDamageReceiver();
        //this.LoadDamageSender();
        this.LoadChickenMovement();
        this.LoadChickenSO();
    }
    protected virtual void LoadChickenSO()
    {
        if (this.chickenSO != null) return;
        string path = "SO/Chicken/" + transform.name;
        this.chickenSO = Resources.Load<ChickenSO>(path);   
        Debug.LogWarning(transform.name + ":  LoadChickenSO", gameObject);
    }
    protected virtual void LoadChickenMovement()
    {
        if (this.chickenMovement != null) return;
        this.chickenMovement = GetComponentInChildren<ChickenMovement>();

        Debug.LogWarning(transform.name + ": LoadChickenMovement", gameObject);
    }
}
