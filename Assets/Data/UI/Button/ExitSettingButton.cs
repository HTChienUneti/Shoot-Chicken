
using UnityEngine;

public class ExitSettingButton : ButtonAbstract
{
    protected override void OnClick()
    {  
        UIStateManager.Instance.SetState(HomeUIState.Instance);
    }
 
}
