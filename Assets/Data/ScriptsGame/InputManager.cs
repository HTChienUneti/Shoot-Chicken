using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class InputManager : MySingleton<InputManager>
{
    [SerializeField] private Vector3 mouseWorldPos;
    [SerializeField] private float fire_1;
    [SerializeField] private float horizontal;
    [SerializeField] private float vertical;
    private Dictionary<KeyCode, List<IUsingKeyDown>> keyDownlisteners = new Dictionary<KeyCode, List<IUsingKeyDown>>();
    private Dictionary<KeyCode, List<IUsingKeyHold>> keyHoldlisteners = new Dictionary<KeyCode, List<IUsingKeyHold>>();
    private List<IUsingMousePos> mousePoslisteners = new List<IUsingMousePos>();
    private List<IUsingMouse> mouseListeners = new List<IUsingMouse>();
    private List<IUsingHoriVertiKey> horizontalListeners = new List<IUsingHoriVertiKey>();

    private void Update()
    {
        this.GetMousePos();
        this.GetMouseDown();
        this.GetHoriVerti();
        this.GetKeyDown();
        this.GetKeyHold();
    }
    public void AddKeyDownListener(KeyCode key, IUsingKeyDown listener)
    {
        if (!this.keyDownlisteners.ContainsKey(key))
        {
            keyDownlisteners[key] = new List<IUsingKeyDown>();
        }
        this.keyDownlisteners[key].Add(listener);
    }
    public void AddKeyHoldListener(KeyCode key, IUsingKeyHold listener)
    {
        if (!this.keyHoldlisteners.ContainsKey(key))
        {
            keyHoldlisteners[key] = new List<IUsingKeyHold>();
        }
        this.keyHoldlisteners[key].Add(listener);
    }

    public void AddMouseActionListener(IUsingMouse listener)
    {
        this.mouseListeners.Add(listener);
    }
    public void AddHoriVertiListener(IUsingHoriVertiKey listener)
    {
        this.horizontalListeners.Add(listener);
    }
    public void RemoveHoriVertiListener(IUsingHoriVertiKey listener)
    {
        this.horizontalListeners.Remove(listener);
    }
    public void AddMousePosListener(IUsingMousePos listener)
    {
        this.mousePoslisteners.Add(listener);
    }
    public void RemoveMousePosListener(IUsingMousePos listener)
    {
        this.mousePoslisteners.Remove(listener);
    }
    private void GetKeyDown()
    {

        foreach (KeyCode key in this.keyDownlisteners.Keys)
        {
            if (Input.GetKeyDown(key))
            {
                this.OnKeyDown(key);
            }
            
        }
    }
    private void GetKeyHold()
    {

        foreach (KeyCode key in this.keyHoldlisteners.Keys)
        {
            if (Input.GetKey(key))
            {
                
                this.OnKeyHold(key);
            }

        }
    }

    private void OnKeyDown(KeyCode key)
    {
        foreach (IUsingKeyDown listener in this.keyDownlisteners[key])
        {
            listener.OnKeyDown();
        }
    }
    private void OnKeyHold(KeyCode key)
    {
        foreach (IUsingKeyHold listener in this.keyHoldlisteners[key])
        {

            listener.OnKeyHold();
        }
    }

    private void OnMouseLeftDown()
    {
        foreach (IUsingMouse listener in this.mouseListeners)
        {
            listener.OnMouseLeftDown();
        }
    }  
    private void OnMouseMove()
    {
        foreach (IUsingMousePos listener in this.mousePoslisteners)
        {
            listener.OnMouseMove(this.mouseWorldPos);
        }
    }
    private void OnHoriVertizontal()
    {
        foreach (IUsingHoriVertiKey listener in this.horizontalListeners)
        {
            listener.OnValueChanged(this.horizontal, this.vertical);
        }
    }
    private void GetMouseDown()
    {
        this.fire_1 = Input.GetAxis("Fire1");
        if (fire_1 != 1) return;
        this.OnMouseLeftDown();
    }
    private void GetHoriVerti()
    {
        this.horizontal = Input.GetAxis("Horizontal");
        this.vertical = Input.GetAxis("Vertical");
        if (this.vertical == 0 && this.horizontal == 0) return;
        this.OnHoriVertizontal();
    }
    private void GetMousePos()
    {
        Vector3 temp = this.mouseWorldPos;
        this.mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        this.mouseWorldPos.z = 0;
        if (temp == this.mouseWorldPos) return;
        this.OnMouseMove();
    }
}
