using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BulletAbility : MyMonoBehaviour, IUsingKeyDown
{
    //----------------Properties----------------------//
    [Header("Bullet Ability")]
    [SerializeField] protected float timeDelay = 5;
    [SerializeField] protected float timeCountdown = 5;
    [SerializeField] protected Ability ability;
    [SerializeField] protected KeyCode keyCode;
    protected List<IUsingBulletAbility> listeners = new List<IUsingBulletAbility>();


    //-----------------Function--------------------//
    protected override void Start()
    {
        base.Start();
        this.timeCountdown = this.timeDelay;
        InputManager.Instance.AddKeyDownListener(this.keyCode, this);
    }
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
        foreach (ItemRequire item in this.ability.requires) 
        {
            bool isContain = false;
            foreach (ItemInventory itemInventory in PlayerCtrl.Instance.Inventory.Items)
            {
                if (itemInventory.item.itemProfile != item.item.itemProfile) continue;
                if (itemInventory.stack < item.count) continue;
                isContain = true;
            }
            if (!isContain) return false;
        }
        return true;
    }
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
       // Debug.Log("countdowning");
    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadAbility();
    }
    protected virtual void LoadAbility()
    {
        if (this.ability != null) return;
        string path = "SO/Ability/" + transform.name;
        this.ability = Resources.Load<Ability>(path);
    }
} 
 
