
using UnityEngine;

public class BulletGreenAbilityButton : ButtonBase
{
    protected override void OnClick()
    {
        Debug.Log("ON click");
        BulletGreenAbility.Instance.OnKeyDown(KeyCode.Alpha2);
    }
}
