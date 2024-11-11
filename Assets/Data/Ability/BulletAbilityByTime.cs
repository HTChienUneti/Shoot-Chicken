using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BulletAbilityByTime : BulletAbility
{
    [Header("Bullet Ability By Time")]
    [SerializeField] protected float timeRemaining;
    [SerializeField] protected float timeUse = 5;
    protected override void OnStartUse()
    {
        StartCoroutine(this.UsingAbility());
        Debug.Log("On use");
    }
    protected virtual IEnumerator UsingAbility()
    {
       
        this.timeRemaining = this.timeUse;

        while (this.timeRemaining > 0)
        {
            this.timeRemaining -= Time.deltaTime;
            // if (BulletAbility.anotherUsed) yield break;
            this.OnUsing();
            yield return new WaitForSeconds(Time.deltaTime);
        }
        base.OnUsing();
    }
}
