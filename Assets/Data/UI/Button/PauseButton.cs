
using UnityEngine;

public class PauseButton : ButtonAbstract
{
    protected override void OnClick()
    {
        this.PauseGame();
    }
    protected virtual void PauseGame()
    {
         GameManager.Instance.PauseGame();
    }
}
