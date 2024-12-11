using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UIAbstract : MyMonoBehaviour
{
    protected override void Start()
    {
        this.Hide();
    }
    public virtual void Hide()
    {
        gameObject.SetActive(false);
    }
    public virtual void Show()
    {
        gameObject.SetActive(true);
    }
}
