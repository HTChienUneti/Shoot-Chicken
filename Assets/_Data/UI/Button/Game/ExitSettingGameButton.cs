
using UnityEngine;

public class ExitSettingGameButton : ButtonBase
{
    protected override void OnClick()
    {  
        GameSceneStateManager.Instance.ChangeState(GamePauseState.Instance);
    }
 
}
