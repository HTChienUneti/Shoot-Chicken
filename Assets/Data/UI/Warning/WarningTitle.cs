using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarningTitle : UIAbstract
{

    [SerializeField] private float timeMax = 1f;
    [SerializeField] private float timer = 0f;
    [SerializeField] private bool isShowing = true;
    [SerializeField] protected SpriteWarning spriteWarning;
    protected override void Start()
    {
        base.Start();
        GameWarningState.Instance.OnEnterState += GameWarningState_OnEnterState;
        GameWarningState.Instance.OnExitState += GameWarningState_OnExitState;
        this.Hide();
    }
    private void GameWarningState_OnEnterState(object sender, System.EventArgs e)
    {
        this.Show();
    }
    private void GameWarningState_OnExitState(object sender, System.EventArgs e)
    {
        this.Hide();
    }
    private void FixedUpdate()
    {
        this.Warning();
    }
    private void Warning()
    {
        this.isShowing = !this.isShowing;
        this.timer += Time.fixedDeltaTime;
        if (this.timer < this.timeMax) return;
        this.timer = 0f;
        if (this.isShowing)
        {
            this.spriteWarning.Show();
        }
        else
        {
            this.spriteWarning.Hide();
        }

    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadSpriteWarning();
    }
    protected virtual void LoadSpriteWarning()
    {
        if (this.spriteWarning != null) return;
        this.spriteWarning = transform.GetComponentInChildren<SpriteWarning>();
        Debug.LogWarning(transform.name + ": LoadSpriteWarning", gameObject);
    }




}
