using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class RocketAbilityUI : AbilityUI, IUsingRocketAbility
{
    protected override void Start()
    {
        base.Start();
        RocketAbility.Instance.AddListener(this);
    }
    protected override void OnClick()
    {
        RocketAbility.Instance.OnKeyDown(KeyCode.Alpha5);
    }
}
