using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class PlayerShooterInputManager : MySingleton<PlayerShooterInputManager>,IUsingKeyHold,IUsingMouse
{
    [SerializeField] protected KeyCode keyShoot = KeyCode.Space;
    protected override void Start()
    {
        base.Start();
        InputManager.Instance.AddKeyHoldListener(this.keyShoot, this);
        InputManager.Instance.AddMouseActionListener( this);
    }
    public void OnMouseLeftDown()
    {
        this.SetShooting();
    }
    public void OnKeyHold()
    {
      this.SetShooting();
    }
    public virtual void SetShooting()
    {
        PlayerCtrl.Instance.Shooter.SetShooting(true);
    }
}
