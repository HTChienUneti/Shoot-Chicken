using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static private GameManager _instance;
    public static GameManager Instance => _instance;
    
    protected List<IPauseGame> pauseListener = new List<IPauseGame>();  
    protected List<IActiveGame> activeListener = new List<IActiveGame>();  
    private void Awake()
    {
        this.LoadSingleton();
    }
    protected virtual void LoadSingleton()
    {
        if(GameManager._instance != null)
        {
            Debug.LogWarning("There are already have a GameManager",gameObject);
            Destroy(gameObject);
        }
        GameManager._instance = this;
    }
    public virtual void AddPauseListener(IPauseGame pauseListener)
    {
        this.pauseListener.Add(pauseListener);
    }
    public virtual void RemovePauseListener(IPauseGame pauseListener)
    {
        this.pauseListener.Remove(pauseListener);
    }
    public virtual void AddActiveListener(IActiveGame activeListener)
    {
        this.activeListener.Add(activeListener);
    }
    public virtual void RemoveActiveListener(IActiveGame activeListener)
    {
        this.activeListener.Remove(activeListener);
    }

    public virtual void PauseGame()
    {
        foreach(IPauseGame listener in pauseListener)
        {
            listener.OnPauseGame();
        }
        Time.timeScale = 0f;
    }
    public virtual void ActiveGame()
    {
        foreach(IActiveGame listener in activeListener)
        {
            listener.OnActiveGame();
        }
        Time.timeScale = 1f;
    }
}
