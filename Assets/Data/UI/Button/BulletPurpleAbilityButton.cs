
using UnityEngine;

public class BulletPurpleAbilityButton : ButtonAbstract
{
    protected override void OnClick()
    {
        BulletPurpleAbility.Instance.OnKeyDown();
    }
}
