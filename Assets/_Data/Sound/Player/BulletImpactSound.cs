using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletImpactSound : SoundBase
{
    protected override void Start()
    {
        base.Start();
        BulletImpactManager.Instance.OnImpact += BulletImpactManager_OnImpact;
    }

    private void BulletImpactManager_OnImpact(object sender, System.EventArgs e)
    {
        this.OnSound();
    }

}
