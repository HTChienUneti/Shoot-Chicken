using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class BulletPurpleAbilityUI : AbilityUI, IUsingBulletPurpleAbility
{
    protected override void Start()
    {
        base.Start();
        BulletPurpleAbility.Instance.AddListener(this);
    }
    protected override void OnClick()
    {
        BulletPurpleAbility.Instance.OnKeyDown(KeyCode.Alpha3);
    }
}
