
using UnityEngine;

public class ResumeButton : ButtonBase
{
    protected override void OnClick()
    {
        this.ResumeGame();
    }
    protected virtual void ResumeGame()
    {
        GameManager.Instance.ActiveGame();
    }
}