using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager : MySingleton<BackgroundManager>
{
    [SerializeField] protected List<BackgroundReaping> backgroundReapings;

    public void SetSpeed(float speed)
    {
        foreach(BackgroundReaping background in backgroundReapings)
        {
            background.SetSpeed(speed);
        }
    }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadBackground();
    }
    protected virtual void LoadBackground()
    {
        if (this.backgroundReapings.Count > 0) return;
        foreach(Transform child in transform)
        {
            this.backgroundReapings.Add(child.GetComponent<BackgroundReaping>());
        }
        Debug.Log(transform.name + ": LoadBackground");
    }
}
