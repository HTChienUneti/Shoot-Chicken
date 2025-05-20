using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MyMonoBehaviour
{
    [Header("Spawner")]
    [SerializeField] protected List<Transform> prefabs;
    [SerializeField] protected List<Transform> pools;
    [SerializeField] protected Transform holder;
    [SerializeField] protected int spawnCount = 0;
  // [SerializeField] protected int spawnLimit = 10;

    public virtual Transform Spawn(string prefabName, Vector3 pos, Quaternion rot)
    {
        //   if (this.spawnCount >= this.spawnLimit) return null;
        Debug.Log(prefabName);
        Transform prefab = this.GetPrefabByName(prefabName);
        if(prefab == null)
        {
            Debug.LogError("Get Prefab By name failed "+ prefabName,gameObject);
            return null;
        }
        Transform obj = this.GetObjFromPool(prefab);
        if (obj == null) obj = this.CreateObj(prefab);
        obj.position = pos;
        obj.rotation = rot;
        this.spawnCount++;
        return obj;
    }
    public virtual void Despawn(Transform obj)
    {
        this.pools.Add(obj);
        obj.gameObject.SetActive(false);
        this.spawnCount--;
    }
    protected virtual Transform CreateObj(Transform prefab)
    {
        Transform obj = Instantiate(prefab,this.holder);
        obj.gameObject.SetActive(false);
        obj.name = prefab.name;
        return obj;
    }
    public virtual Transform GetObjFromPool(Transform prefab)
    {
      
        foreach (Transform obj in this.pools)
        {
            if (obj.name != prefab.name) continue;
            this.pools.Remove(obj);
            return obj;
        }
        return null; ;

    }
    protected virtual Transform GetPrefabByName(string prefabName)
    {
        foreach (Transform prefab in this.prefabs)
        {
            if (prefab.name == prefabName) return prefab;
        }
        return null;
    }




    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadPrefabs();
        this.LoadHolder();
    }
    protected virtual void LoadPrefabs()
    {
        if (this.prefabs.Count > 0) return;
        Transform prefabs = transform.Find("Prefabs");
        foreach (Transform prefab in prefabs)
        {
            prefab.gameObject.SetActive(false);
            this.prefabs.Add(prefab);
        }
        Debug.LogWarning(transform.name + ": LoadPrefabs", gameObject);
    }
    protected virtual void LoadHolder()
    {
        if (this.holder != null) return;
        this.holder = transform.Find("Holder");
        Debug.LogWarning(transform.name + ": LoadHolder", gameObject);
    }
}
