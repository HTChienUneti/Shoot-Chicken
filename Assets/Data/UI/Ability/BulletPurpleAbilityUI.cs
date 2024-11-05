using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class BulletPurpleAbilityUI : AbilityUIAbstract, IUsingBulletPurpleAbility
{
    protected override void Start()
    {
        base.Start();
        BulletPurpleAbility.Instance.AddListener(this); 
    }
}
