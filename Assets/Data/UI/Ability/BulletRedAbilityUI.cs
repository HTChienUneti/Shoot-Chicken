using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class BulletRedAbilityUI : AbilityUI, IUsingBulletRedAbility
{
    protected override void OnClick()
    {
     
        BulletRedAbility.Instance.OnKeyDown();
    }

    protected override void Start()
    {
        base.Start();
        BulletRedAbility.Instance.AddListener(this);
    }
 
}
