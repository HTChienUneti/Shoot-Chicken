using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUI : ImageTextBase
{
    protected override void Start()
    {
        base.Start();
        this.countText.text = PlayerCtrl.Instance.DamageReceiver.HpMax.ToString();
        PlayerCtrl.Instance.DamageReceiver.OnChangedHp += PlayerCtrl_DamageReceiver_OnChangedHp;
        
    }

    private void PlayerCtrl_DamageReceiver_OnChangedHp(object sender, DamageReceiver.OnChangedHpEventArgs e)
    {
        this.countText.text = e.hp.ToString();
    }
}