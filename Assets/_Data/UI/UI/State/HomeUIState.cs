using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeUIState : MySingleton<HomeUIState>, IUIState
{
    [SerializeField] protected List<IHomeUI> homeUIs = new List<IHomeUI>();
    public void AddHomeUI(IHomeUI homeUI)
    {
        this.homeUIs.Add(homeUI);
    }
    public void EnterState()
    {
        foreach (IHomeUI homeUI in homeUIs)
        {
            homeUI.Open();
        }

    }

    public void ExitState()
    {
        foreach (IHomeUI homeUI in homeUIs)
        {
            homeUI.Close();
        }

    }
}
