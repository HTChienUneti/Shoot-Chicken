
using UnityEngine;

public class ExitSettingGameButton : ButtonBase
{
    protected override void OnClick()
    {  
        GameSceneStateManager.Instance.SetState(GamePauseState.Instance);
    }
 
}
