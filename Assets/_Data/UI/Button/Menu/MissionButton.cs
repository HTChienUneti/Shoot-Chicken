using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MissionButton : ButtonBase,IHomeUI
{
    [SerializeField] protected Animator animator;
    protected override void Start()
    {
        base.Start();
        HomeUIState.Instance.AddHomeUI(this);
    }
    protected override void OnClick()
    {
        UIStateManager.Instance.SetState(MissionUIState.Instance);
    }
    public void Close()
    {
        this.animator.SetTrigger("Close");
    }

    public void Open()
    {
        this.animator.SetTrigger("Open");
    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadAnim();
    }
    protected virtual void LoadAnim()
    {
        if (this.animator != null) return;
        this.animator = GetComponent<Animator>();
        Debug.LogWarning(transform.name + ": LoadAnim", gameObject);
    }
}
