using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class BulletGreenAbilityUI : AbilityUIAbstract, IUsingBulletGreenAbility
{
    protected override void Start()
    {
        base.Start();
        BulletGreenAbility.Instance.AddListener(this); 
    }
}
