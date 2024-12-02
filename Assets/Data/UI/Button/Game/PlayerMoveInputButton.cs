using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class PlayerMoveInputButton : ButtonBase
{
    [SerializeField] protected ObjParentMovement objParentMovement;
    protected override void OnClick()
    {
        PlayerMoveInputManager.Instance.SetInput(this.objParentMovement);
        PlayerMoveInputUIManager.Instance.SetInput(this.button);

    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadMovement();
    }
    protected virtual void LoadMovement()
    {
        if (this.objParentMovement != null) return;
        PlayerCtrl player = Transform.FindAnyObjectByType<PlayerCtrl>();
        this.LoadParentMovement(player);

        Debug.LogWarning(transform.name + " PlayerFollowMouse", gameObject);
    }
    protected abstract void LoadParentMovement(PlayerCtrl playerCtrl);
}
