using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletUI : InventoryUI, IShooterChangeDamaging
{
    protected override void Start()
    {
        base.Start();
        PlayerCtrl.Instance.Shooter.AddListener(this);
        this.OnChangedObjDamaging(PlayerCtrl.Instance.Shooter.CurrentDamaging);
    }
    public void OnChangedObjDamaging(WeaponSO damagingSO)
    {
        this.image.sprite = damagingSO.itemProfile.sprite;
    }
}
