using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : HittableObjCtrl
{
    [Header("PlayerCtrl")]
    private static PlayerCtrl _instance;
    public static PlayerCtrl Instance => _instance;
    [SerializeField] protected Inventory inventory;
    public Inventory Inventory => inventory;
    [SerializeField] protected PlayerShooter shooter;
    public PlayerShooter Shooter=>shooter;
    [SerializeField] protected PlayerMoveByKey playerMoveByKey;
    public PlayerMoveByKey PlayerMoveByKey=> playerMoveByKey;
    [SerializeField] protected PlayerFollowMouse playerFollowMouse;
    public PlayerFollowMouse PlayerFollowMouse => playerFollowMouse;

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
        this.LoadPlayerMoveByKey();
        this.LoadPlayerFollowMouse();
      
    }
    protected virtual void LoadPlayerFollowMouse()
    {
        if (this.playerFollowMouse != null) return;
        this.playerFollowMouse = GetComponentInChildren<PlayerFollowMouse>();
        Debug.Log(transform.name + ": LoadPlayerFollowMouse", gameObject);
    }
    protected virtual void LoadPlayerMoveByKey()
    {
        if (this.playerMoveByKey != null) return;
        this.playerMoveByKey = GetComponentInChildren<PlayerMoveByKey>();
        Debug.Log(transform.name + ": LoadPlayerMoveByKey", gameObject);
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
