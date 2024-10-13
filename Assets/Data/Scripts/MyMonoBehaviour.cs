using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyMonoBehaviour : MonoBehaviour
{
    protected virtual void Awake()
    {
       // this.LoadComponent();
    }
    protected virtual void Start()
    {
        this.LoadComponent();
    }

    protected virtual void Reset()
    {
        this.LoadComponent() ;
    }
    protected virtual void LoadComponent()
    {
        //for override
    }
}
