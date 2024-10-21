using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDespawn : DespawnByDistance
{
    protected override void GetTarget()
    {
        this.target = Camera.main.transform;
    }
}
