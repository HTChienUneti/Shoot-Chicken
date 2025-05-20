using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondsUI : UITop, IHomeUI
{
    protected override void Start()
    {
        base.Start();
        HomeUIState.Instance.AddHomeUI(this);
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
