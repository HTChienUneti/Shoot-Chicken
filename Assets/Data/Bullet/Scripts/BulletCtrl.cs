using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCtrl : DamagingObjCtrl
{
    [SerializeField] protected SpriteRenderer model;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadModel();
    }
    protected virtual void LoadModel()
    {
        if (this.model != null) return;
        this.model = GetComponentInChildren<SpriteRenderer>();
        this.model.sprite = this.damagingSO._sprite;
        Debug.LogWarning(transform.name + ": LoadModel", gameObject);
    }
    public virtual void SetModel(Sprite sprite)
    {
        this.model.sprite = sprite;
    }

}
