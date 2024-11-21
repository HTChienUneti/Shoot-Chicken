using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class BulletGreenAbilityUI : AbilityUI, IUsingBulletGreenAbility
{
  

    protected override void Start()
    {
        base.Start();
        BulletGreenAbility.Instance.AddListener(this); 
    }
    protected override void OnClick()
    {
            BulletGreenAbility.Instance.OnKeyDown();
    }
}
