using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageReceiver : DamageReceiver
{
    //use for player revive
    [SerializeField] protected Vector3 defaultPos = new Vector3(0, -3.43f, 0);
    protected override void OnDead()
    {
        GameManager.Instance.OverGame();
    }
    protected override void ResetValue()
    {
       this.defaultPos = new Vector3(0, -3.43f, 0);
   
    }

    protected override void CreateVfXReceiveDamage()
    {
        Transform vfx = VFXSpawner.Instance.Spawn(VFXSpawner.impact_1, transform.parent.position, Quaternion.identity);
        if (vfx == null) return;
        vfx.gameObject.SetActive(true);
        transform.parent.gameObject.SetActive(false);
        Invoke(nameof(this.Revive), 2f);
    }
    protected virtual void Revive()
    {
        transform.parent.gameObject.SetActive(true);
        transform.parent.position = this.defaultPos;
    }

    protected override void LoadCollider()
    {
        base.LoadCollider();
        this._collider.radius = 1f;
    }
}
