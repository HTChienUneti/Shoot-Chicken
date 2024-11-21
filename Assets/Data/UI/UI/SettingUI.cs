using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingUI : MySingleton<SettingUI>,ISettingUI
{
    protected override void Start()
    {
        base.Start();
        this.Hide();
        SettingUIState.Instance.AddSettingUI(this);
    }
    public virtual void Show()
    {
        gameObject.SetActive(true);
    }
    public virtual void Hide()
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
}
