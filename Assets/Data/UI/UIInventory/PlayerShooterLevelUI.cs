using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooterLevelUI : InventoryUI, IUsingShooterLevel
{
    protected override void Start()
    {
        base.Start();
        this.countText.text = PlayerCtrl.Instance.Shooter.ShooterLevel.CurrentLevel.ToString();
        PlayerCtrl.Instance.Shooter.ShooterLevel.AddListener(this);  
    }

    public void OnChangeLevel(int currentLevel)
    {
        this.countText.text = currentLevel.ToString();  
    }
}