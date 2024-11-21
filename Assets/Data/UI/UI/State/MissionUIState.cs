using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionUIState : MySingleton<MissionUIState>, IUIState
{
    [SerializeField] protected List<IMissionUI> missionUIs = new List<IMissionUI>();
    public void AddMissionUI(IMissionUI missionUI)
    {
        this.missionUIs.Add(missionUI);
    }
    public void EnterState()
    {
        foreach (IMissionUI missionUI in missionUIs)
        {
            missionUI.Open();
        }

    }

    public void ExitState()
    {
        foreach (IMissionUI missionUI in missionUIs)
        {
            missionUI.Close();
        }

    }
}
