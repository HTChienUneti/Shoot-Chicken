
using UnityEngine;

public class MenuButton : ButtonBase
{
    protected override void OnClick()
    {
        this.BackToMenu();
    }
    protected virtual void BackToMenu()
    {
        LoadSceneManager.Instance.LoadScene(LoadSceneManager.Scene.MenuScene);

        Time.timeScale = 1.0f;
    }
}
