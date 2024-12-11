using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextMissionButton : ButtonBase
{
    protected override void OnClick()
    {
        MissionSO currentMission= MissionDataManager.Instance.Mission;
        MissionSO Nextmission = null; 
        int currentMissionIndex = currentMission.missionIndex;
        currentMissionIndex++;
        string path = "Mission/";
        MissionSO[] missions = Resources.LoadAll<MissionSO>(path);
        foreach(MissionSO mission in missions)
        {
            if (mission.missionIndex != currentMissionIndex) continue;
            Nextmission = mission;break ;
        }
        if (Nextmission == null) return;
        MissionDataManager.Instance.Mission = Nextmission;
        Debug.Log(Nextmission.missionIndex);
        LoadSceneManager.Instance.LoadScene(LoadSceneManager.Scene.GameScene);
    }
}
