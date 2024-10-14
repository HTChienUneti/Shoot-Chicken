using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class QuitButton : ButtonAbstract
{
    protected override void OnClick()
    {
        this.QuitGame();
    }
    protected virtual void QuitGame()
    {
        if (UnityEditor.EditorApplication.isPlaying)
        {
            UnityEditor.EditorApplication.ExitPlaymode();
        }
        else
        {
            Application.Quit();
        }
    }
}
