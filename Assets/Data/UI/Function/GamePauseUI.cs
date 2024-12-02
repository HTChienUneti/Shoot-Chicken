using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePauseUI : MySingleton<GamePauseUI>,IGamePauseState,IUsingKeyDown
{
    [SerializeField] protected bool isShowing = false;
    protected override void Start()
    {
        InputManager.Instance.AddKeyDownListener(KeyCode.Escape,this);
        this.Hide();
    }
    protected virtual void Hide()
    {
        gameObject.SetActive(false);
    }
    protected virtual void Show()
    {
        gameObject.SetActive(true);
    }

    public void EnterState()
    {
        this.Show();
        Debug.Log("Gamepause state");
    }

    public void ExcuseState()
    {
        throw new System.NotImplementedException();
    }

    public void ExitState()
    {
        this.Hide();
    }

    public void OnKeyDown()
    {
        this.isShowing =! this.isShowing;
        if(this.isShowing)
        {
            GameManager.Instance.PauseGame();
        }
        else
        {
            GameManager.Instance.ActiveGame();
        }
       
    }
}
