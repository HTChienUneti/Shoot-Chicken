using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Despawn : MyMonoBehaviour
{
    
    protected virtual void FixedUpdate()
    {
        this.TryDespawn();
    }
    protected abstract bool TryDespawn();
    protected virtual void DespawnObj()
    {

    }
}
