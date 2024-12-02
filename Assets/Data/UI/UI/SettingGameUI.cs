using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingGameUI : MySingleton<SettingGameUI>, ISettingState
{
    [SerializeField] protected Animator animator;
    protected override void Start()
    {
        base.Start();
        this.DisActive();

    }
    public virtual void Show()
    {
        gameObject.SetActive(true);
     //   this.animator.SetTrigger("Open");
    }
    public virtual void Hide()
    {
      //  this.animator.SetTrigger("Close");
        Invoke(nameof(this.DisActive), 1f);
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

    public void EnterState()
    {
        this.Show();
    }

    public void ExcuseState()
    {

    }

    public void ExitState()
    {
        this.DisActive();
    }   
}
