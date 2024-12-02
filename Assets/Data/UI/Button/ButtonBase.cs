using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class ButtonBase : MyMonoBehaviour
{
    [SerializeField] protected Button button;
    protected override void Start()
    {
        base.Start();
        this.button.onClick.AddListener(OnClick);
    }
    protected abstract void OnClick();

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadButton();
    }
    protected virtual void LoadButton()
    {
        if (this.button != null) return;
        this.button = GetComponent<Button>();
        Debug.Log(transform.name + ": LoadButton", gameObject);
    }
}
