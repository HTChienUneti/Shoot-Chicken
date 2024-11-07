
using UnityEngine;

public class SettingButton : ButtonAbstract
{
    protected override void OnClick()
    {
        this.OnSetting();
    }
    protected virtual void OnSetting()
    {
        transform.parent.gameObject.SetActive(false);
        SettingUI.Instance.Show();
    }
}
