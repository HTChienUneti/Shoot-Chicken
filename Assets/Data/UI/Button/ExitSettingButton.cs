
using UnityEngine;

public class ExitSettingButton : ButtonAbstract
{
    protected override void OnClick()
    {
        this.OnSetting();
    }
    protected virtual void OnSetting()
    {
       transform.parent.gameObject.SetActive(false);
        GameManager.Instance.PauseGame();
    }
}
