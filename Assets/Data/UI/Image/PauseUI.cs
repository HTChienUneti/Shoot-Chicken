using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseUI : MonoBehaviour, IPauseGame, IActiveGame
{
    protected virtual void Start()
    {
        this.Hide();
        GameManager.Instance.AddPauseListener(this);
        GameManager.Instance.AddActiveListener(this);
    }
    public void OnPauseGame()
    {
        this.Show();
    }
    public void OnActiveGame()
    {
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


}
