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
        this.ResetValue();
    }
    protected virtual void OnEnable()
    {
        this.ResetValue();
    }
    protected virtual void OnDisable()
    {
        this.ResetValue();
    }
    protected virtual void ResetValue()
    {

    }

    protected virtual void Reset()
    {
        this.LoadComponent() ;
        this.ResetValue() ;
    }
    protected virtual void LoadComponent()
    {
        //for override
    }
}
