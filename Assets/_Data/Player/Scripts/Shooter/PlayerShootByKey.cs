using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class PlayerShootByKey : MyMonoBehaviour
{
    public virtual void SetShooting(bool isShooting)
    {
        PlayerCtrl.Instance.Shooter.SetShooting(isShooting);
    }
}
