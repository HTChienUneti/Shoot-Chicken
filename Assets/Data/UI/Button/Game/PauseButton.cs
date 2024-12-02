
using UnityEngine;

public class PauseButton : ButtonBase
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
