using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class PlayerUpgradeShooter : UpdateShooter
{
    [SerializeField] protected PlayerShooter shooter;
    protected override void Start()
    {
        base.Start();
        this.shooter.PlayerCtrl.Inventory.OnInventoryChanged += Inventory_OnInventoryChanged;
    }

    private void Inventory_OnInventoryChanged(object sender, Inventory.OnInventoryChangedEventArgs e)
    {
        ItemPower itemPower = this.GetItemPowerByProfile(e.Item.itemSO.itemProfile);
        if (itemPower == null) return;
        this.Upgrade(itemPower);
    }
    protected virtual ItemPower GetItemPowerByProfile(Profile profile)
    {
        foreach (ItemPower power in this.shooter.PlayerShooterSO.powers)
        {
            if (power.profile != profile) continue;
            return power;
        }
        return null;
    }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadShooter();
    }
    protected virtual void LoadShooter()
    {
        if (this.shooter != null) return;
        this.shooter = GetComponentInParent<PlayerShooter>();
        Debug.LogWarning(transform.name + " LoadShooter", gameObject);
    }
}
