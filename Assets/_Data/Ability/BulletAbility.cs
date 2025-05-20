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
    public virtual void OnKeyDown(KeyCode k)
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
                if (itemInventory.itemSO.itemProfile != item.itemSO.itemProfile) continue;
                if (itemInventory.stack < item.count) continue;
                isContain = true;
            }
            if (!isContain) return false;
        }
        return true;
    }
    protected virtual void OnStartUse()
    {
        Inventory inventory = PlayerCtrl.Instance.Inventory;
        List<ItemInventory> items = inventory.Items;
        foreach (ItemRequire itemRequire in this.ability.requires)
        {
            inventory.RemoveItem(itemRequire.itemSO, itemRequire.count);
        }
    }
    protected virtual void OnUsing()    
    {
        this.OnUsed();
    }
    protected virtual void OnUsed()
    {
   //     Debug.Log("Used");
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
 
