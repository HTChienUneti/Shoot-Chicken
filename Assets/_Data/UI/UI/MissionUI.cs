using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionUI : MySingleton<MissionUI>,IMissionUI
{
    [SerializeField] protected Animator animator;
    public event EventHandler<EventArgs> OnOpened;
    public event EventHandler<EventArgs> OnClosed;
    protected override void Start()
    {
        base.Start();
        MissionUIState.Instance.AddMissionUI(this);
        this.DisActive();
    }
    public void Show()
    {
        gameObject.SetActive(true);
        this.animator.SetTrigger("Open");
        this.OnOpened?.Invoke(this, EventArgs.Empty);
        
    }
    public void Hide()
    {

        this.animator.SetTrigger("Close");
        Invoke("DisActive", .7f);
        this.OnClosed?.Invoke(this, EventArgs.Empty);
    }
    protected virtual void DisActive()
    {
        gameObject.SetActive(false);
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
    public void Open()
    {
        this.Show();
    }

    public void Close()
    {
        this.Hide();
    }
}
