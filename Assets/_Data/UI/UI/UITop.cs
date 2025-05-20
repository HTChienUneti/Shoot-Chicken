using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITop :MyMonoBehaviour 
{

    [SerializeField] protected Animator animator;

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
