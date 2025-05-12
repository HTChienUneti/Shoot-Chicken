using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using UnityEngine;

public class PlayerRevive : PlayerAbstract
{
    [SerializeField] protected bool isReviving = false;
    [SerializeField] protected float timer;
    [SerializeField] protected float timeDelay = .2f;
    [SerializeField] protected float TimeRevive = 6f;
    [SerializeField] protected float delayRevive = 3f;
    [SerializeField] protected bool isShowing = true;

    protected override void ResetValue()
    {
        this.defaultPos = new Vector3(0, -3.43f, 0);
    }
    [SerializeField] protected Vector3 defaultPos = new Vector3(0, -3.43f, 0);
    public virtual void Revive()
    {
        StartCoroutine(this.DelayRevive());
    }
    protected IEnumerator DelayRevive()
    {
        this.Hide();
        yield return new WaitForSeconds(this.delayRevive);
        this.isReviving = true;
        transform.parent.position = this.defaultPos;
     
        StartCoroutine(nameof(this.Countdown));
    }
    protected virtual void FixedUpdate()
    {
        this.Reviving();
    }
    protected virtual IEnumerator Countdown()
    {
        yield return new WaitForSeconds(this.TimeRevive);
        this.isReviving = false;
        this.playerCtrl.DamageReceiver.gameObject.SetActive(true);
        this.Show();
    }
    public virtual void Reviving()
    {
        if (!this.isReviving) return;
        this.timer += Time.fixedDeltaTime;
        if (this.timer < timeDelay) return;
        this.timer = 0;
        if (this.isShowing)
        {
            this.Hide();
           
        }
        else
        {
            this.Show();
            
        }
    }
    protected virtual void Show()
    {
        this.playerCtrl.Model.gameObject.SetActive(true);
       

        this.isShowing = true;
    }
    protected virtual void Hide()
    {
        this.playerCtrl.Model.gameObject.SetActive(false);
        this.playerCtrl.DamageReceiver.gameObject.SetActive(false);
        this.isShowing = false;
    }
}