using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class RocketAbilityUI : AbilityUIAbstract, IUsingRocketAbility
{
    protected override void Start()
    {
        base.Start();
       // RocketAbility.Instance.AddListener(this);
    }
 
}
