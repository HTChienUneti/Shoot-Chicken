using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Diagnostics;

public abstract class BulletAbility : MyMonoBehaviour
{
    [Header("Bullet Ability")]
    [SerializeField] protected float timeRemaining;
    [SerializeField] protected float timeDelay = 10;
    [SerializeField] protected float timeCountdown;
    [SerializeField] protected bool isUsed = false;
    [SerializeField] static private bool isUsing = false;
    [SerializeField] protected float timeUse = 10f;
    protected List<IUsingBulletAbility> listeners = new List<IUsingBulletAbility>();
    public virtual void AddListener(IUsingBulletAbility listener)
    {
        this.listeners.Add(listener);
    }
    public virtual void OnKeyDown()
    {
        if (!PlayerCtrl.Instance.Inventory.Contains(transform.name)) return;
        if (this.isUsed || ChangeBulletAbility.isUsing) return;
        this.OnUse();
    }
    protected virtual void OnUse()
    {
        BulletAbility.isUsing = true;
        StartCoroutine(this.UsingAbility());
        Debug.Log("On use");
    }
    protected virtual IEnumerator UsingAbility()
    {
        PlayerCtrl.Instance.Inventory.RemoveItem(transform.name, 1);
        this.timeRemaining = this.timeUse;

        while (this.timeRemaining > 0)
        {
            this.timeRemaining -= Time.fixedDeltaTime;
            AbilityBulletManager.Instance.SetUsing(this.timeRemaining, this.timeUse);
            this.SetUsing();
            yield return new WaitForSeconds(0.02f);
        }
        ChangeBulletAbility.isUsing = false;
        this.isUsed = true;
        this.Used();
        StartCoroutine(this.Countdown());
    }
    protected virtual void Used()
    {

    }
    protected abstract void SetUsing();
    protected virtual void SetCountdown()
    {

    }
    protected virtual IEnumerator Countdown()
    {
        this.timeCountdown = 0;
        while (this.timeCountdown < this.timeDelay)
        {
            this.timeCountdown += Time.fixedDeltaTime;
            this.SetCountdown();
            //   this.shooterAbilities.SetCountdown(this.timeCountdown,this.timeDelay);
            yield return new WaitForSeconds(0.02f);

        }
        this.isUsed = false;
    }
}
