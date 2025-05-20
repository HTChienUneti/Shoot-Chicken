using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Despawn : MyMonoBehaviour
{

    protected virtual void FixedUpdate()
    {
          if(!this.TryingDespawn())return;
        this.DespawnObj();
    }
    protected abstract bool TryingDespawn();
    protected abstract void DespawnObj();

}
