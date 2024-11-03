using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class PlayerShooter : ObjectShooter//, IUsingInventory
{
    [SerializeField] protected bool autoShoot = false;
    [SerializeField] protected PlayerCtrl playerCtrl;
    public PlayerCtrl PlayerCtrl => playerCtrl;
    protected override void Start()
    {
        base.Start();
        //this.playerCtrl.Inventory.AddListener(this);
    }
    protected override void Shooting()
    {
        if (!this.autoShoot)
            if (InputManager.Instance.Fire_1 == 0) return;
        base.Shooting();
    }
    protected override Transform GetPrefab()
    {
        Transform newBullet = BulletSpawner.Instance.Spawn(this.damagingSO, this.startPos.position, Quaternion.identity);
        return newBullet;
    }

    protected override string GetDamagingName()
    {
        return "Bullet_Blue";
    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadPlayerCtrl();
    }
    protected virtual void LoadPlayerCtrl()
    {
        if (this.playerCtrl != null) return;
        this.playerCtrl = transform.parent.GetComponent<PlayerCtrl>();
        Debug.LogWarning(transform.name + ": LoadPlayerCtrl", gameObject);
    }

    public void OnInventoryChanged(ItemDrop item)
    {
        ItemType itemType = item.itemType;
        switch (itemType)
        {
            case ItemType.Damaging:
                this.SetDamaging(item.itemCode.ToString());
               // this.playerCtrl.Inventory.RemoveItem(item);
                break;
            case ItemType.Resource:
                this.SetRerouce(item);
                break;
            case ItemType.PowerUp:
                this.shooterLevel.LevelUp(item.ItemTypePowerup,item.count);
           //     this.playerCtrl.Inventory.RemoveItem(item);
                break;

        }
    }
    public virtual void SetRerouce(ItemDrop item)
    {

    }
}
