using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class BulletRedAbilityUI : AbilityUIAbstract, IUsingBulletRedAbility
{
    protected override void Start()
    {
        base.Start();
        BulletRedAbility.Instance.AddListener(this);
    }
 
}
