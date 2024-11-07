using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Diagnostics;

public abstract class BulletAbility : MyMonoBehaviour
{
    [Header("Bullet Ability")]
    [SerializeField] protected float timeRemaining;
    [SerializeField] protected float timeDelay = 5;
    [SerializeField] protected float timeCountdown;
    [SerializeField] protected bool isUsed = false;
  //  [SerializeField]static  protected bool anotherUsed = false;
  
    [SerializeField] protected float timeUse = 5;
    protected List<IUsingBulletAbility> listeners = new List<IUsingBulletAbility>();
    public virtual void AddListener(IUsingBulletAbility listener)
    {
        this.listeners.Add(listener);
    }
    public virtual void OnKeyDown()
    {
       if (!PlayerCtrl.Instance.Inventory.Contains(transform.name)) return;
        this.OnStartUse();
    }
    protected virtual void OnStartUse()
    {
        StartCoroutine(this.UsingAbility());
        Debug.Log("On use");
    }
    protected virtual IEnumerator UsingAbility()
    {
        PlayerCtrl.Instance.Inventory.RemoveItem(transform.name, 1);
        this.timeRemaining = this.timeUse;

        while (this.timeRemaining > 0)
        {
            this.timeRemaining -= Time.deltaTime;
           // if (BulletAbility.anotherUsed) yield break;
            this.OnUsing();
            yield return new WaitForSeconds(Time.deltaTime);
        }
        this.isUsed = true;
        this.OnUsed();
        StartCoroutine(this.Countdown());
    }
    protected abstract void OnUsed();
    protected virtual void OnUsing()
    {

    }
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
