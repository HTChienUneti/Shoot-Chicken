using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [Header("InputManager")]
    private static InputManager _instance;   
    public static InputManager Instance=>_instance;
    [SerializeField]protected  Vector3 mouseWorldPos;
    //public Vector3 MouseWorldPos=>mouseWorldPos;
    [SerializeField] protected float fire_1;
    //public float Fire_1=> fire_1;
    protected List<IUsingInputAlpha1> Alpha1listeners = new List<IUsingInputAlpha1>();   
    protected List<IUsingInputAlpha2> Alpha2listeners = new List<IUsingInputAlpha2>();   
    protected List<IUsingInputAlpha3> Alpha3listeners = new List<IUsingInputAlpha3>();   
    protected List<IUsingInputAlpha4> Alpha4listeners = new List<IUsingInputAlpha4>();   
    protected List<IUsingInputKeyE> keyElisteners = new List<IUsingInputKeyE>();   
    protected List<IUsingMousePos> MousePoslisteners = new List<IUsingMousePos>();   
    protected List<IUsingMouseDown> MouseDownlisteners= new List<IUsingMouseDown>();   
    protected virtual void Awake()
    {
        if(InputManager._instance != null)
        {
            Debug.LogError("There are have more than 1 InputManager");
            return;
        }
        InputManager._instance = this;   
    }
    protected void Update()
    {
        this.GetMousePos();
        this.GetMouseLeftDown();
        this.GetKeyDown();
    }
    public virtual void AddKeyEListener(IUsingInputKeyE listener)
    {
        this.keyElisteners.Add(listener);
    }
    public virtual void AddAlpha1Listener(IUsingInputAlpha1 listener)
    {
        this.Alpha1listeners.Add(listener);
    }
    public virtual void AddAlpha2Listener(IUsingInputAlpha2 listener)
    {
        this.Alpha2listeners.Add(listener);
    }
    public virtual void AddAlpha3Listener(IUsingInputAlpha3 listener)
    {
        this.Alpha3listeners.Add(listener);
    }
    public virtual void AddAlpha4Listener(IUsingInputAlpha4 listener)
    {
        this.Alpha4listeners.Add(listener);
    }
    public virtual void AddMousedownListener(IUsingMouseDown listener)
    {
        this.MouseDownlisteners.Add(listener);
    }
    public virtual void AddMousePosListener(IUsingMousePos listener)
    {
        this.MousePoslisteners.Add(listener);
    }
    protected virtual void GetKeyDown()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            this.OnAlpha1Down();
        }
        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            this.OnAlpha2Down();
        }
        if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            this.OnAlpha3Down();

        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            this.OnAlpha4Down();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            this.OnKeyEDown();
        }

    }
    protected virtual void OnKeyEDown()
    {
        foreach (IUsingInputKeyE listener in this.keyElisteners)
        {
            listener.OnKeyDown();
        }
    }
    protected virtual void OnAlpha1Down()
    {
        foreach(IUsingInputAlpha1 listener in this.Alpha1listeners)
        {
            listener.OnKeyDown();
        }
    }
    protected virtual void OnAlpha2Down()
    {
        foreach (IUsingInputAlpha2 listener in this.Alpha2listeners)
        {
            listener.OnKeyDown();
        }
    }
    protected virtual void OnAlpha3Down()
    {
        foreach (IUsingInputAlpha3 listener in this.Alpha3listeners)
        {
            listener.OnKeyDown();
        }
    }
    protected virtual void OnAlpha4Down()
    {
        foreach (IUsingInputAlpha4 listener in this.Alpha4listeners)
        {
            listener.OnKeyDown();
        }
    }
    protected virtual void OnMouseLeftDown()
    {
        foreach (IUsingMouseDown listener in this.MouseDownlisteners)
        {
            listener.OnMouseLeftDown(this.fire_1);
        }
    }
    protected virtual void OnMouseMove()
    {
        foreach (IUsingMousePos listener in this.MousePoslisteners)
        {
            listener.OnMouseMove(this.mouseWorldPos);
        }
    }
    protected virtual void GetMouseLeftDown()
    {
        this.fire_1 = Input.GetAxis("Fire1");
        this.OnMouseLeftDown();
    }
    protected virtual void GetMousePos()
    {
        this.mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        this.mouseWorldPos.z = 0;
        this.OnMouseMove();
    }
}
