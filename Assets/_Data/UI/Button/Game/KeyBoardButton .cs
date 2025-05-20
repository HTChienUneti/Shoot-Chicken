using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KeyBoardButton : PlayerMoveInputButton
{
    protected override void LoadParentMovement(PlayerCtrl playerCtrl)
    {
        this.objParentMovement = playerCtrl.PlayerMoveByKey;
    
    }
}
