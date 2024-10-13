using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectShooter : MyMonoBehaviour
{
    [Header("Obj Shooter")]
    [SerializeField] protected float shootDelay = 2f;
    [SerializeField] protected float shootTimer = 0f;
    [SerializeField] protected Transform startPos;
    protected string prefabName;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadStartPos();
    }
    protected virtual void LoadStartPos()
    {
        if (this.startPos != null) return;
        this.startPos = transform.Find("StartPos");
        Debug.LogWarning(transform.name + ": LoadStartPos", gameObject);
    }
    protected override void Start()
    {
        this.shootTimer = 0f;
    }

    protected virtual void FixedUpdate()
    {
        this.Shooting();
    }
    protected virtual void Shooting()
    {
        if (!this.CountdownTime()) return;
        this.prefabName = this.GetPrefabName();
        Transform prefab = this.GetPrefab();
        if (prefab == null) return;
        prefab.gameObject.SetActive(true);
    }
    protected abstract Transform GetPrefab();  
    protected abstract string GetPrefabName();
    protected virtual bool CountdownTime()
    {
        this.shootTimer += Time.fixedDeltaTime;
        if (this.shootTimer < this.shootDelay) return false;
        this.shootTimer = 0f;
        return true;
    }
}
