using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class ImageTextBase : MyMonoBehaviour
{
    [SerializeField] protected Image image;
    [SerializeField] protected TextMeshProUGUI countText;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadSprite();
        this.LoadCountText();
    }

    protected virtual void LoadSprite()
    {
        if (this.image != null) return;
        this.image = GetComponentInChildren<Image>();
        Debug.Log(transform.name + ": LoadSprite", gameObject);
    }
    protected virtual void LoadCountText()
    {
        if (this.countText != null) return;
        this.countText = GetComponentInChildren<TextMeshProUGUI>();
        Debug.Log(transform.name + ": LoadCountText", gameObject);
    }
}
