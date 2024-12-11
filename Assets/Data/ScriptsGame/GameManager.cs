using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MySingleton<GameManager>
{
    [SerializeField] private bool isGameActive = false;
    public virtual void PauseGame()
    {
        GameSceneStateManager.Instance.SetState(GamePauseState.Instance);
    }
    public virtual void ActiveGame()
    {
        this.isGameActive = true;  
  
        GameSceneStateManager.Instance.SetState(GameActiveState.Instance);
    }
    public virtual void WarningGame()
    {
        GameSceneStateManager.Instance.SetState(GameWarningState.Instance);
    }
    public virtual void OverGame()
    {
        GameSceneStateManager.Instance.SetState(GameOverState.Instance);
    }
    public virtual void WinGame()
    {
        Invoke(nameof(this.TriggerWin), 5f);
        
    }
    protected virtual void TriggerWin()
    {
        GameSceneStateManager.Instance.SetState(GameWinState.Instance);
    }
    public virtual void SettingGame()
    {
        GameSceneStateManager.Instance.SetState(GameSettingsState.Instance);
    }
    public virtual void StartIntroGame()
    {
        GameSceneStateManager.Instance.SetState(GameIntroState.Instance);
    }
    public virtual bool IsGameActive()
    {
        return this.isGameActive;
    }
    public void BackPrevState()
    {
        GameSceneStateManager.Instance.SetState(GameSceneStateManager.Instance.PrevState);
        Time.timeScale = 1f;
    }
}
