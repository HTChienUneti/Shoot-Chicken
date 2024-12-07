using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroGame : MySingleton<IntroGame>, IIntroState
{
    public void EnterState()
    {
        Debug.Log("Enter IntroGame state");

        BackgroundManager.Instance.SetSpeed(20);
        StartCoroutine(CountdownIntro());
    }
    protected IEnumerator CountdownIntro()
    {
        yield return new WaitForSeconds(3f);
        GameManager.Instance.ActiveGame();
    }

    public void ExcuseState()
    {
        throw new System.NotImplementedException();
    }

    public void ExitState()
    {
        Debug.Log("Exit IntroGame state");
        BackgroundManager.Instance.SetSpeed(5f);
    }
}
