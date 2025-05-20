using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextMissionButton : ButtonBase
{
    protected override void OnClick()
    {
        MissionSO currentMission= MissionDataManager.Instance.Mission;

        int currentMissionIndex = currentMission.missionIndex;
        currentMissionIndex++;
        string path = "SO/Mission/Mission_"+currentMissionIndex+"/"+"Mission_"+currentMissionIndex;
        MissionSO nextMission = Resources.Load<MissionSO>(path);
        Debug.Log(path);
        if (nextMission == null) return;
        MissionDataManager.Instance.Mission = nextMission;
        Debug.Log(nextMission.missionIndex);
        LoadSceneManager.Instance.LoadScene(LoadSceneManager.Scene.GameScene);
    }
}
