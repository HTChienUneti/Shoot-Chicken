using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputManager : MySingleton<PlayerInputManager>
    , IUsingMousePos, IUsingHoriVertiKey, IUsingMouse, IUsingInput
{
    protected override void Start()
    {
        base.Start();
        InputManager.Instance.AddMousePosListener(this);
        InputManager.Instance.AddMouseActionListener(this);
        InputManager.Instance.AddHoriVertiListener(this);
        InputManager.Instance.AddKeyListener(this.GetKeyCode(),this);
    }
    protected virtual KeyCode GetKeyCode()
    {
        return KeyCode.Space;
    }
    public void OnMouseMove(Vector3 mousePos)
    {
        PlayerCtrl.Instance.PlayerFollowMouse.SetTargetPos(mousePos);
    }
    public void OnValueChanged(float horizontal, float vertical)
    {
        PlayerCtrl.Instance.PlayerMoveByKey.SetKeyValue(horizontal, vertical);
    }

    public void OnKeySpaceUp()
    {
        PlayerShooterInputManager.Instance.SetShootByKey(false);
    }

    public void OnMouseLeftDown()
    {
        PlayerShooterInputManager.Instance.SetShootByMouse(true);
    }

    public void OnMouseLeftUp()
    {
        PlayerShooterInputManager.Instance.SetShootByKey(false);
    }

    public void OnKeyDown()
    {
        PlayerShooterInputManager.Instance.SetShootByKey(true);
    }
}
