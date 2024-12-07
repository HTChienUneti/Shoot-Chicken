using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenCtrl : DamagingObjCtrl
{
    [SerializeField] protected ChickenMovement chickenMovement;
    public ChickenMovement ChickenMovement => chickenMovement;
    [SerializeField] protected ChickenSO chickenSO;
    public ChickenSO ChickenSO=> chickenSO;


    public override void EnterState()
    {
        base.EnterState();
        this.SetActive(true);
    }
    public override void ExitState()
    {
        base.ExitState();
        this.SetActive(false);
    }
    protected virtual void SetActive(bool active)
    {
        this.chickenMovement.IsMoving = active;
    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
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
