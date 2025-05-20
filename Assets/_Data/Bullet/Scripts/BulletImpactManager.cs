using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BulletImpactManager :MySingleton<BulletImpactManager>
{
    public event EventHandler<EventArgs> OnImpact;
    public virtual void SetImpact()
    {
        this.OnImpact?.Invoke(this, EventArgs.Empty);
    }
}
