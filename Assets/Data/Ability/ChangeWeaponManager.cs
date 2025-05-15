using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class ChangeWeaponManager : PlayerAbstract,IUsingKeyDown
{
    static private ChangeWeaponManager _instance;
    static public ChangeWeaponManager Instance => _instance;
    private List<IUsingBulletAbility> listeners = new List<IUsingBulletAbility>();
    [SerializeField] private PlayerShooter shooter;
    protected override void Awake()
    {
        base.Awake();
        this.LoadSingleton();
    }
    private void LoadSingleton()
    {
        if (ChangeWeaponManager._instance != null)
        {
            Debug.LogError("There are already have a ShooterAbilities");
            return;
        }
        ChangeWeaponManager._instance = this;
    }

    protected override void Start()
    {
        base.Start();
        foreach(PlayerWeaponSO weapon in this.playerCtrl.PlayerSO.weapons)
        {
            InputManager.Instance.AddKeyDownListener(weapon.keycode, this);
        }
        
    }
    public  void AddListener(IUsingBulletAbility listener)
    {
        this.listeners.Add(listener);
    }
    public void RemoveListener(IUsingBulletAbility listener)
    {
        this.listeners.Remove(listener);
    }
    public void OnKeyDown(KeyCode keycode)
    {
        foreach(PlayerWeaponSO weapon in this.playerCtrl.PlayerSO.weapons)
        {
            if (weapon.keycode != keycode) continue;
            Debug.Log(keycode.ToString());
            this.ChangeWeapon(weapon);  
        }
    }
    private void ChangeWeapon(PlayerWeaponSO weapon)
    {
        this.shooter.SetWeapon(weapon);
    }
    #region LoadComponent
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadShooter();
    }
    protected override PlayerCtrl GetPlayCtrlComponent()
    {
        return GetComponentInParent<PlayerCtrl>();
    }
    private void LoadShooter()
    {
        if (this.shooter != null) return;
        this.shooter = GetComponentInParent<PlayerShooter>();
        Debug.LogWarning(transform.name + " LoadShooter", gameObject);
    }
    #endregion
}
