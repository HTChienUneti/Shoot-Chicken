using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewGameButton : ButtonBase
{
    protected override void OnClick()
    { 
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        GameManager.Instance.PlayGame();
    }
}
