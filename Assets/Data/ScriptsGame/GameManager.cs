using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MySingleton<GameManager>
{
    public virtual void PauseGame()
    {
        Time.timeScale = 0f;
        GameSceneStateManager.Instance.SetState(GamePauseUI.Instance);
    }
    public virtual void ActiveGame()
    {

        Time.timeScale = 1f;
        GameSceneStateManager.Instance.SetState(GameActiveState.Instance);
    }
    public virtual void OverGame()
    {
        GameSceneStateManager.Instance.SetState(GameOverUI.Instance);
    }
    public virtual void WinGame()
    { 
        GameSceneStateManager.Instance.SetState(WinUI.Instance);
    }
    public virtual void SettingGame()
    {
        GameSceneStateManager.Instance.SetState(SettingGameUI.Instance);
    }
}
