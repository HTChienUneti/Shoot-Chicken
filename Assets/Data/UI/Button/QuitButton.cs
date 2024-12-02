
using UnityEngine;

public class QuitButton : ButtonBase
{
    protected override void OnClick()
    {
        this.QuitGame();
    }
    protected virtual void QuitGame()
    {

        Application.Quit();

    }
}
