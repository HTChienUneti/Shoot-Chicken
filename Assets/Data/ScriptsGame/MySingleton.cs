using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MySingleton<T> : MyMonoBehaviour where T : MyMonoBehaviour
{
    static private T _instance;
    static public T Instance =>_instance;
    protected override void Awake()
    {
        base.Awake();
        this.LoadSingleton();
    }
    protected virtual void LoadSingleton()
    {
        if(_instance != null)
        {
            Debug.LogWarning("There are already have a "+typeof(T).Name, gameObject);
            Destroy(gameObject);
            Debug.LogWarning("Deleted new "+typeof (T).Name, gameObject);
            return;
        }
        _instance = this as T;
    }
}
