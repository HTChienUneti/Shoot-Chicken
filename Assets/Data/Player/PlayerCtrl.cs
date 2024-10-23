using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MyMonoBehaviour
{
    [Header("PlayerCtrl")]
    private static PlayerCtrl _instance;
    public static PlayerCtrl Instance => _instance;
    [SerializeField] protected Inventory inventory;
    public Inventory Inventory => inventory;
    [SerializeField] protected PlayerShooter shooter;
    public  PlayerShooter Shooter =>shooter;


    protected override void Awake()
    {
        base.Awake();
        this.LoadSingleton();
      
    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadInventory();
        this.LoadShooter();
    }
      protected virtual void LoadShooter()
    {
        if (this.shooter != null) return;
        this.shooter = GetComponentInChildren<PlayerShooter>();
        Debug.Log(transform.name + ": LoadShooter", gameObject);
    }
    protected virtual void LoadInventory()
    {
        if (this.inventory != null) return;
        this.inventory = GetComponentInChildren<Inventory>();
        Debug.Log(transform.name + ": LoadInventory", gameObject);
    }
    protected virtual void LoadSingleton()
    {
        if (PlayerCtrl._instance != null)
        {
            Debug.LogError("There are have more than one PlayerCtrl");
            return;
        }
        PlayerCtrl._instance = this;
    }

}
