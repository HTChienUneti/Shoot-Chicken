using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MissionBase : ButtonAbstract
{
    [SerializeField] protected MissionSO missionSO;
    protected override void OnClick()
    {
        DataManager.Instance.Mission = this.missionSO;
        LoadSceneManager.Instance.LoadScene(LoadSceneManager.Scene.GameScene);
        
    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadMissionSO();
    }
    protected virtual void LoadMissionSO()
    {
        if (this.missionSO != null) return;
        string path = "Mission/" + transform.name;
        this.missionSO = Resources.Load<MissionSO>(path);
        Debug.Log(transform.name + ": LoadMission", gameObject);
    }
}
