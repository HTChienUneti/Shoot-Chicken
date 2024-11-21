using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingUIState : MySingleton<SettingUIState>, IUIState
{
    [SerializeField] protected List<ISettingUI> settingUIs = new List<ISettingUI>();
    public void AddSettingUI(ISettingUI settingUI)
    {
        this.settingUIs.Add(settingUI);
    }
    public void EnterState()
    {
      
        foreach (ISettingUI settingUI in settingUIs)
        {
            settingUI.Open();
        }

    }

    public void ExitState()
    {
        foreach (ISettingUI settingUI in settingUIs)
        {
            settingUI.Close();
        }

    }
}
