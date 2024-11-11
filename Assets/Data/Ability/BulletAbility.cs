using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BulletAbility : MyMonoBehaviour, IUsingInput
{
    //----------------Properties----------------------//
    [Header("Bullet Ability")]
    [SerializeField] protected float timeDelay = 5;
    [SerializeField] protected float timeCountdown = 5;
    protected List<IUsingBulletAbility> listeners = new List<IUsingBulletAbility>();


    //-----------------Function--------------------//
    protected override void Start()
    {
        base.Start();
        this.timeCountdown = this.timeDelay;
        InputManager.Instance.AddKeyListener(this.GetKeyCode(), this);
    }
    protected abstract KeyCode GetKeyCode();
    public virtual void AddListener(IUsingBulletAbility listener)
    {
        this.listeners.Add(listener);
    }
    public virtual void OnKeyDown()
    {
        if (!this.HaveEnoughItem() || this.timeCountdown < this.timeDelay) return;
        this.OnStartUse();
    }
    protected virtual bool HaveEnoughItem()
    {
        foreach (Ingredient ingredient in this.GetIngredient()) 
        {
            bool isContain = false;
            foreach (ItemInventory itemInventory in PlayerCtrl.Instance.Inventory.Items)
            {
                if (itemInventory.itemProfile != ingredient.profile) continue;
                if (itemInventory.stack < ingredient.count) continue;
                isContain = true;
            }
            if (!isContain) return false;
        }
        return true;
    }
    protected abstract List<Ingredient> GetIngredient();
    protected virtual void OnStartUse()
    {
      //  PlayerCtrl.Instance.Inventory.RemoveItem(this.itemRequire, this.require);
        //this.OnUsing();
    }
    protected virtual void OnUsing()
    {
        this.OnUsed();
    }
    protected virtual void OnUsed()
    {
        Debug.Log("Used");
        StartCoroutine(this.Countdown());
    }
    protected virtual IEnumerator Countdown()
    {
        this.timeCountdown = 0;
        while (this.timeCountdown < this.timeDelay)
        {
            this.timeCountdown += Time.fixedDeltaTime;
            this.Countdowning();
            //   this.shooterAbilities.SetCountdown(this.timeCountdown,this.timeDelay);
            yield return new WaitForSeconds(0.02f);

        }
    }
    protected virtual void Countdowning()
    {
        Debug.Log("countdowning");
    }
} 
 
