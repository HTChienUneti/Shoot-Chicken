using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePauseUI : MySingleton<GamePauseUI>,IUsingKeyDown,IGamePauseState
{
    [SerializeField] protected bool isShowing = false;
    protected override void Start()
    {
        InputManager.Instance.AddKeyDownListener(KeyCode.Escape,this);
        GamePauseState.Instance.AddListenter(this);
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

    public void OnKeyDown()
    {
        this.isShowing =! this.isShowing;
        if(this.isShowing)
        {
            GameManager.Instance.PauseGame();
        }
        else
        {
            GameManager.Instance.BackPrevState();
        }
       
    }

    public void EnterState()
    {
        this.Show();
    }

    public void ExcuseState()
    {
        throw new System.NotImplementedException();
    }

    public void ExitState()
    {
        this.Hide();
    }
}
