using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : ButtonAbstract
{
    protected override void OnClick()
    {
        SceneManager.LoadScene("GameScene");
    }
}
