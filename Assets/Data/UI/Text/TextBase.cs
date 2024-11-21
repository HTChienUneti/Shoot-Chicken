using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextBase : MyMonoBehaviour
{
    [Header("Text base")]
    [SerializeField] protected TextMeshProUGUI text;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadText();
    }
    protected virtual void LoadText()
    {
        if (this.text != null) return;
        this.text = GetComponent<TextMeshProUGUI>();
        Debug.LogWarning(transform.name + ": LoadText", gameObject);
    }
}
