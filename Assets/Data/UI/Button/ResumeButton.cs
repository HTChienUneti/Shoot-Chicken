
using UnityEngine;

public class ResumeButton : ButtonAbstract
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