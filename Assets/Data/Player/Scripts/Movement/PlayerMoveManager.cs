using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMoveManager : MySingleton<PlayerMoveManager>,IUsingMousePos,IUsingHoriVertiKey                                                                    
{
    [SerializeField] protected List<ObjParentMovement> inputs = new List<ObjParentMovement>();
    [SerializeField] protected PlayerFollowMouse followMouse;
    [SerializeField] protected PlayerMoveByKey moveByKey;
    [SerializeField] protected PlayerMoveUp playerMoveUp;
    [SerializeField] protected bool isUseMouse = false;
    [SerializeField] protected bool isUseKey = false;
    protected override void Start()
    {
        base.Start();
        InputManager.Instance.AddMousePosListener(this);
        InputManager.Instance.AddHoriVertiListener(this);
        GameSceneStateManager.Instance.OnGameChangedState += GameSceneStateManager_OnGameChangedState;
        this.isUseKey = false;
        this.isUseMouse = false;
    }
    protected virtual void GameSceneStateManager_OnGameChangedState(object sender,OngameChangedStateArgs e)
    {
      
        if (e.state.Equals(GameActiveState.Instance))
        {
            Debug.Log("GameActive");
            this.isUseKey = true;
            this.isUseMouse = true;
        }
        else if(e.state.Equals(GameWinState.Instance))
        {
            Invoke(nameof(this.DelayEnter), 3f);
        }
        else
        {
            this.isUseKey = false;
            this.isUseMouse = false;
        }
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
      //  this.followMouse.SetTargetPos(mousePos);
    }
    public void OnValueChanged(float horizontal, float vertical)
    {
        if (!this.isUseKey) return;
        this.moveByKey.SetKeyValue(horizontal, vertical);
    }

    protected virtual void DelayEnter()
    {
        this.isUseMouse = false;
        this.isUseKey = false;
        this.followMouse.SetSpeed(3);
        this.followMouse.SetBoundY(30);
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
}
