using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MouseButton : PlayerMoveInputButton
{
    protected override void Start()
    {
        base.Start();
        this.button.image.color = new(0, 1, 1, 1);
    }
    protected override void LoadParentMovement(PlayerCtrl playerCtrl)
    {
        this.objParentMovement = playerCtrl.PlayerFollowMouse;
     
    }
}
