
using UnityEngine;

public class QuitButton : ButtonAbstract
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
