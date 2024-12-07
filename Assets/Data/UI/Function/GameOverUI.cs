using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverUI : MySingleton<GameOverUI>
{
    protected override void Start()
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
