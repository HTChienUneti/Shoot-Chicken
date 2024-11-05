using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Diagnostics;

public class Add1Ability : BulletAbility,IUsingInputKeyE
{
    protected override void Start()
    {
        base.Start();
        InputManager.Instance.AddKeyEListener(this);    
    }
    protected override void SetUsing()
    {
       
    }
    protected override void SetCountdown()
    {
        base.SetCountdown();
    }
}
