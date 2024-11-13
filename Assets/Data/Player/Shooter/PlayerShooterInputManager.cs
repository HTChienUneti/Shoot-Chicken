using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class PlayerShooterInputManager : MySingleton<PlayerShooterInputManager>,IUsingKeyHold,IUsingMouse
{
    [SerializeField] protected bool isShooting = false;
    [SerializeField] protected PlayerShootByKey shootByKey;
    [SerializeField] protected PlayerShootByMouse shootByMouse;
    protected override void Start()
    {
        base.Start();
        InputManager.Instance.AddKeyHoldListener(KeyCode.Space, this);
        InputManager.Instance.AddMouseActionListener( this);
    }

    public void OnKeyHold()
    {
      this.SetShooting();
    }

    public virtual void SetShootByKey(bool isShooting)
    {
        this.isShooting = isShooting;
        shootByKey.gameObject.SetActive(true);
        shootByMouse.gameObject.SetActive(false);
      //  this.SetShooting(isShooting);
    }
    public virtual void SetShootByMouse(bool isShooting)
    {
        this.isShooting = isShooting;
        shootByMouse.gameObject.SetActive(true);
        shootByKey.gameObject.SetActive(false);
       // this.SetShooting(isShooting);
    }
    public virtual void SetShooting()
    {
        PlayerCtrl.Instance.Shooter.SetShooting(true);
    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadShootByKey();
        this.LoadShootByMouse();
    }
    protected virtual void LoadShootByKey()
    {
        if (this.shootByKey != null) return;
        this.shootByKey = GetComponentInChildren<PlayerShootByKey>();
        Debug.LogWarning(transform.name + ": LoadShootByKey", gameObject);
    }
    protected virtual void LoadShootByMouse()
    {
        if (this.shootByMouse != null) return;
        this.shootByMouse = GetComponentInChildren<PlayerShootByMouse>();
        Debug.LogWarning(transform.name + ": LoadShootByMouse", gameObject);
    }

    public void OnMouseLeftDown()
    {
        this.SetShooting();
    }

}
