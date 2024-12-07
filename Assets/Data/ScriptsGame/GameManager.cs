using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MySingleton<GameManager>
{
    [SerializeField] private bool isGameActive = false;
    public virtual void PauseGame()
    {
        Time.timeScale = 0f;
        GameSceneStateManager.Instance.SetState(GamePauseState.Instance);
    }
    public virtual void ActiveGame()
    {
        this.isGameActive = true;  
        Time.timeScale = 1f;
        GameSceneStateManager.Instance.SetState(GameActiveState.Instance);
    }
    public virtual void OverGame()
    {
        Time.timeScale = 0f;
        GameSceneStateManager.Instance.SetState(GameOverState.Instance);
    }
    public virtual void WinGame()
    { 
        GameSceneStateManager.Instance.SetState(GameWinState.Instance);
    }
    public virtual void SettingGame()
    {
        GameSceneStateManager.Instance.SetState(SettingGameUI.Instance);
    }
    public virtual void StartIntroGame()
    {
        GameSceneStateManager.Instance.SetState(IntroGame.Instance);
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
