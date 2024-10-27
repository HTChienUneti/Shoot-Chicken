using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MyMonoBehaviour
{
    [SerializeField] protected Image _sprite;
    [SerializeField] protected TextMeshProUGUI countText;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadSprite();
        this.LoadCountText();

    }
    protected virtual void LoadSprite()
    {
        if (this._sprite != null) return;
        this._sprite = GetComponentInChildren<Image>();
        Debug.Log(transform.name + ": LoadSprite", gameObject);
    }
    protected virtual void LoadCountText()
    {
        if (this.countText != null) return;
        this.countText = GetComponentInChildren<TextMeshProUGUI>();
        Debug.Log(transform.name + ": LoadCountText", gameObject);
    }
}

