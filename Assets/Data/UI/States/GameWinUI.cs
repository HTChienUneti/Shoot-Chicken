using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameWinUI : MySingleton<GameWinUI>
{
    [SerializeField] protected Animator animator;
    [SerializeField] protected bool isShowing = false;
   
    protected override void Start()
    {
        base.Start();
        this.Hide();
        GameWinState.Instance.OnEnterState += GameWinState_OnEnterState;
    }

    private void GameWinState_OnEnterState(object sender, EventArgs e)
    {
        this.Show();
;    }

    public void Show()
    {
        gameObject.SetActive(true);
        this.animator.SetTrigger("Open");

    }
    public void Hide()
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

  
}
