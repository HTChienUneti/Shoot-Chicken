
using UnityEngine;

public class BulletPurpleAbilityButton : ButtonBase
{
    protected override void OnClick()
    {
        BulletPurpleAbility.Instance.OnKeyDown();
    }
}
