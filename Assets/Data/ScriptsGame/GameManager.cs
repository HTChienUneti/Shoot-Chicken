using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static private GameManager _instance;
    public static GameManager Instance => _instance;

    protected List<IPauseGame> pauseListeners = new List<IPauseGame>();
    protected List<IActiveGame> activeListeners = new List<IActiveGame>();
    protected List<IOverGame> gameOverlisteners = new List<IOverGame>();
    private void Awake()
    {
        this.LoadSingleton();
    }
    protected virtual void LoadSingleton()
    {
        if (GameManager._instance != null)
        {
            Debug.LogWarning("There are already have a GameManager", gameObject);
            Destroy(gameObject);
        }
        GameManager._instance = this;
    }
    public virtual void AddPauseListener(IPauseGame pauseListener)
    {
        this.pauseListeners.Add(pauseListener);
    }
    public virtual void RemovePauseListener(IPauseGame pauseListener)
    {
        this.pauseListeners.Remove(pauseListener);
    }
    public virtual void AddActiveListener(IActiveGame activeListener)
    {
        this.activeListeners.Add(activeListener);
    }
    public virtual void RemoveActiveListener(IActiveGame activeListener)
    {
        this.activeListeners.Remove(activeListener);
    }
    public virtual void AddGameOverListener(IOverGame gameOverListener)
    {
        this.gameOverlisteners.Add(gameOverListener);
    }
    public virtual void RemoveGameOverListener(IOverGame gameOverListener)
    {
        this.gameOverlisteners.Remove(gameOverListener);
    }
    public virtual void PauseGame()
    {
        foreach (IPauseGame listener in pauseListeners)
        {
            listener.OnPauseGame();
        }
        Time.timeScale = 0f;
    }
    public virtual void ActiveGame()
    {
        foreach (IActiveGame listener in activeListeners)
        {
            listener.OnActiveGame();
        }
        Time.timeScale = 1f;
    }
    public virtual void OverGame()
    {
        foreach (IOverGame listener in this.gameOverlisteners)
        {
            listener.OnGameOver();
        }
    }
}
