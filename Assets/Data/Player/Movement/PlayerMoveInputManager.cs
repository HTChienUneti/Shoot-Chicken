using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMoveInputManager : MySingleton<PlayerMoveInputManager>,IUsingMousePos,IUsingHoriVertiKey
{
    [SerializeField] protected List<ObjParentMovement> inputs = new List<ObjParentMovement>();
    [SerializeField] protected PlayerFollowMouse followMouse;
    [SerializeField] protected PlayerMoveByKey moveByKey;
    protected override void Start()
    {
        base.Start();
        InputManager.Instance.AddMousePosListener(this);
        InputManager.Instance.AddHoriVertiListener(this);
    }

    public virtual void SetInput(ObjParentMovement objParentMovement)
    {
        objParentMovement.gameObject.SetActive(true);
        foreach (ObjParentMovement input  in this.inputs)
        {
            if (input == objParentMovement) continue;
            input.gameObject.SetActive(false);

        }
    }

    public void OnMouseMove(Vector3 mousePos)
    {
        this.followMouse.SetTargetPos(mousePos);
    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadInput();
    }
    protected virtual void LoadInput()
    {
        if (this.inputs.Count != 0) return;
        this.followMouse = Transform.FindObjectOfType<PlayerFollowMouse>();
        this.inputs.Add(followMouse);
        this.moveByKey = Transform.FindObjectOfType<PlayerMoveByKey>();
        this.inputs.Add(moveByKey);
    }

    public void OnValueChanged(float horizontal, float vertical)
    {
        this.moveByKey.SetKeyValue(horizontal, vertical);   
    }
}
