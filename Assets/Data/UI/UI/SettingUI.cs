using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingUI : MySingleton<SettingUI>,ISettingUI
{
    [SerializeField] protected Animator animator;
    protected override void Start()
    {
        base.Start();
        this.DisActive();
        SettingUIState.Instance.AddSettingUI(this);
    }
    public virtual void Show()
    {
        gameObject.SetActive(true);
        this.animator.SetTrigger("Open");
    }
    public virtual void Hide()
    {
        this.animator.SetTrigger("Close");
        Invoke(nameof(this.DisActive), .5f);
    }
    protected virtual void DisActive()
    {
        gameObject.SetActive(false);
    }

    public void Open()
    {
        this.Show();
    }

    public void Close()
    {
        this.Hide();
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
