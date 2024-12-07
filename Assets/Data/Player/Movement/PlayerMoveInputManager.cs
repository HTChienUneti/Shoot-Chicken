using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMoveInputManager : MySingleton<PlayerMoveInputManager>,IUsingMousePos,IUsingHoriVertiKey
                                                                        ,IGameWinState
                                                                        
{
    [SerializeField] protected List<ObjParentMovement> inputs = new List<ObjParentMovement>();
    [SerializeField] protected PlayerFollowMouse followMouse;
    [SerializeField] protected PlayerMoveByKey moveByKey;
    [SerializeField] protected bool isUseMouse = true;
    protected override void Start()
    {
        base.Start();
        InputManager.Instance.AddMousePosListener(this);
        InputManager.Instance.AddHoriVertiListener(this);
        GameWinState.Instance.AddListener(this);
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
        if (!this.isUseMouse) return;
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

    public void EnterState()
    {
       
     
    }

    public void ExcuseState()
    {
        this.isUseMouse = false;
        this.followMouse.SetSpeed(30);
        this.followMouse.SetBoundY(30);
        Debug.Log(followMouse.transform.parent.up);
        this.followMouse.SetTargetPos(this.followMouse.transform.parent.position + new Vector3(0,1,0));
    }

    public void ExitState()
    {
        this.isUseMouse = true;
   
        this.followMouse.SetSpeed(10);
    }
}
