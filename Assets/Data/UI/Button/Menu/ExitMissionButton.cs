
using UnityEngine;

public class ExitMissionButton : ButtonBase
{
    [SerializeField] protected MissionUI missionUI;
    protected override void OnClick()
    {
        this.ExitMissionUI();
    }
    protected virtual void ExitMissionUI()
    {
        this.missionUI.Hide();
        UIStateManager.Instance.SetState(HomeUIState.Instance);
    }

}
