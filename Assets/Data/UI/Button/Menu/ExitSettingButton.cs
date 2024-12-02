
using UnityEngine;

public class ExitSettingButton : ButtonBase
{
    protected override void OnClick()
    {  
        UIStateManager.Instance.SetState(HomeUIState.Instance);
    }
 
}
