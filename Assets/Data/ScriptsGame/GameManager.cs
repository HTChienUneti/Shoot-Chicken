using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MySingleton<GameManager>
{
  
    public virtual void PauseGame()
    {
        GameSceneStateManager.Instance.ChangeState (GamePauseState.Instance);
        Time.timeScale = 0f;
    }
    public virtual void PlayGame()
    {
        Time.timeScale = 1f;
        GameSceneStateManager.Instance.ChangeState(PlayingGameState.Instance);
    }
  
    public virtual void WarningGame()
    {
        GameSceneStateManager.Instance.ChangeState(GameWarningState.Instance);
        Time.timeScale = 1f;
    }
    public virtual void OverGame()
    {
        GameSceneStateManager.Instance.ChangeState(GameOverState.Instance);
        Invoke(nameof(this.PauseTime), 2f);
    }
    private void PauseTime()
    {
        Time.timeScale = 0f;
    }
    public virtual void WinGame()
    {
        GameSceneStateManager.Instance.ChangeState(GameWinState.Instance);
        Invoke(nameof(this.PauseTime), 2f);
    }
    public virtual void SettingGame()
    {
        GameSceneStateManager.Instance.ChangeState(GameSettingsState.Instance);
    }
    public virtual void StartIntroGame()
    {
        GameSceneStateManager.Instance.ChangeState(GameIntroState.Instance);
        Time.timeScale = 1f;
    }
    public void BackPrevState()
    {
        GameSceneStateManager.Instance.ChangeState(GameSceneStateManager.Instance.PrevState);
        Time.timeScale = 1f;
    }
}
