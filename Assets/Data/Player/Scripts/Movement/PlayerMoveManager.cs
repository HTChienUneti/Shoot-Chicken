using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveManager : MySingleton<PlayerMoveManager>                                                                    
{
    [SerializeField] protected List<ObjParentMovement> inputs = new List<ObjParentMovement>();
    [SerializeField] protected PlayerFollowMouse followMouse;
    [SerializeField] protected PlayerMoveByKey moveByKey;
    [SerializeField] protected PlayerMoveUp playerMoveUp;
    protected override void Start()
    {
        base.Start();
        GameSceneStateManager.Instance.OnGameChangedState += GameSceneStateManager_OnGameChangedState;

    }
    protected virtual void GameSceneStateManager_OnGameChangedState(object sender,OngameChangedStateArgs e)
    {
      
        if (e.state.Equals(PlayingGameState.Instance)|| e.state.Equals(GameWarningState.Instance))
        {
            this.SetMoveByKey(true);
            this.SetMoveByMouse(true);
            this.SetMoveUp(false);
        }
        else if(e.state.Equals(GameWinState.Instance))
        {
            Invoke(nameof(this.MoveUp), 1f);
        }
    }
    protected virtual void MoveUp()
    {
        this.SetMoveByKey(false);
        this.SetMoveByMouse(false);
        this.SetMoveUp(true);
    }
    protected virtual void SetMoveByMouse(bool active)
    {
        this.followMouse.gameObject.SetActive(active);
    }
    protected virtual void SetMoveByKey(bool active)
    {
        this.moveByKey.gameObject.SetActive(active);
    }
    protected virtual void SetMoveUp(bool active)
    {
        this.playerMoveUp.gameObject.SetActive(active);
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
        this.playerMoveUp = Transform.FindObjectOfType<PlayerMoveUp>();
        this.inputs.Add(playerMoveUp);
    }
}
