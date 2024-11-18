
using UnityEngine;

public class BulletGreenAbilityButton : ButtonAbstract
{
    protected override void OnClick()
    {
        Debug.Log("ON click");
        BulletGreenAbility.Instance.OnKeyDown();
    }
}
