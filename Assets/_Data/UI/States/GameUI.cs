using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class GameUI : MyMonoBehaviour
{

    [SerializeField] protected Animator animator;
    [SerializeField] protected bool isShowing = false;
    protected override void Start()
    {
        base.Start();
        this.Hide();
    }
    protected virtual void Hide()
    {
        gameObject.SetActive(false);
    }
    protected virtual void Show()
    {
        gameObject.SetActive(true);
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
