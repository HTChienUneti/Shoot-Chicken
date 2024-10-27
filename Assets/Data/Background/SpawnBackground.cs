using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBackground : MyMonoBehaviour
{
 
    public virtual void Spawn()
    {
        string backgroundName = BackgroundSpawner.background_1;
        Vector3 pos = new Vector3(0, 15, 0);
        Quaternion rot = Quaternion.identity;
        Transform background = BackgroundSpawner.Instance.Spawn(backgroundName,pos,rot);
        if (background == null) return;
        background.gameObject.SetActive(true);
    }
 }
