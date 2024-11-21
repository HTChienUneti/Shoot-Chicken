using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleText : TextBase, IHomeUI
{
    [SerializeField] protected Animator animator;
    protected override void Start()
    {
        base.Start();
        HomeUIState.Instance.AddHomeUI(this);
    }
    public void Close()
    {
        this.animator.SetTrigger("ScaleDown");
    }

    public void Open()
    {
        this.animator.SetTrigger("ScaleUp");
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
