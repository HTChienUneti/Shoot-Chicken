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
    [SerializeField] protected PlayerRevive playerRevive;
    public PlayerRevive PlayerRevive =>playerRevive;
    [SerializeField] protected Transform model;
    public Transform Model => model;
    [SerializeField] protected PlayerSO playerSO;
    public PlayerSO PlayerSO =>playerSO;
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
        this.LoadPlayerRevive();
        this.LoadModel();
        this.LoadPlayerSO();
      
    }
    protected virtual void LoadPlayerSO()
    {
        if (this.playerSO != null) return;
        string path = "SO/Player/"+transform.name;
        this.playerSO = Resources.Load<PlayerSO>(path); 
        Debug.LogWarning(transform.name + ": LoadPlayerSO", gameObject);
    }

    protected virtual void LoadModel()
    {
        if (this.model != null) return;
        this.model = transform.Find("Model");
        Debug.LogWarning(transform.name + ": LoadModel", gameObject);
    }

    protected virtual void LoadPlayerRevive()
    {
        if (this.playerRevive != null) return;
        this.playerRevive = GetComponentInChildren<PlayerRevive>();
        Debug.LogWarning(transform.name + ": LoadPlayerRevive", gameObject);
    }
    protected virtual void LoadPlayerFollowMouse()
    {
        if (this.playerFollowMouse != null) return;
        this.playerFollowMouse = GetComponentInChildren<PlayerFollowMouse>();
        Debug.LogWarning(transform.name + ": LoadPlayerFollowMouse", gameObject);
    }
    protected virtual void LoadPlayerMoveByKey()
    {
        if (this.playerMoveByKey != null) return;
        this.playerMoveByKey = GetComponentInChildren<PlayerMoveByKey>();
        Debug.LogWarning(transform.name + ": LoadPlayerMoveByKey", gameObject);
    }
    protected virtual void LoadShooter()
    {
        if (this.shooter != null) return;
        this.shooter = GetComponentInChildren<PlayerShooter>();
        Debug.LogWarning(transform.name + ": LoadShooter", gameObject);
    }
    protected virtual void LoadInventory()
    {
        if (this.inventory != null) return;
        this.inventory = GetComponentInChildren<Inventory>();
        Debug.LogWarning(transform.name + ": LoadInventory", gameObject);
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
