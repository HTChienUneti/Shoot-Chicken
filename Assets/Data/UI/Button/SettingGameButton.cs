
using UnityEngine;

public class SettingGameButton : ButtonBase
{
    protected override void OnClick()
    {
        GameManager.Instance.SettingGame();
    }
}