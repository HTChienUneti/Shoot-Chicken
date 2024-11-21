using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUI : ImageTextBase, IUsingCurrentHp
{
    protected override void Start()
    {
        base.Start();
        this.countText.text = PlayerCtrl.Instance.DamageReceiver.HpMax.ToString();
        PlayerCtrl.Instance.DamageReceiver.AddListener(this);
        
    }
    public void OnReceivedDamage(int currentHp)
    {
        this.countText.text = currentHp.ToString();
    }
}