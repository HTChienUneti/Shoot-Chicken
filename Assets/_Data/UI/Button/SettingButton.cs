
using UnityEngine;

public class SettingButton : ButtonBase,IHomeUI
{
    [SerializeField] protected Animator animator;
    protected override void Start()
    {
        base.Start();
        HomeUIState.Instance.AddHomeUI(this);
    }

    protected override void OnClick()
    {
        UIStateManager.Instance.SetState(SettingUIState.Instance);

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

    public void Close()
    {
        this.animator.SetTrigger("Close");
    }

    public void Open()
    {
        this.animator.SetTrigger("Open");
    }
}
