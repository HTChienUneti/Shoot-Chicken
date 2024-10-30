using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [Header("InputManager")]
    private static InputManager _instance;   
    public static InputManager Instance=>_instance;
    [SerializeField]protected  Vector3 mouseWorldPos;
    public Vector3 MouseWorldPos=>mouseWorldPos;
    [SerializeField] protected float fire_1;
    public float Fire_1=> fire_1;
    protected virtual void Awake()
    {
        if(InputManager._instance != null)
        {
            Debug.LogError("There are have more than 1 InputManager");
            return;
        }
        InputManager._instance = this;   
    }
    protected void FixedUpdate()
    {
        this.GetMousePos();
        this.GetMouseDown();
    }
    protected virtual void GetMouseDown()
    {
        this.fire_1 = Input.GetAxis("Fire1");
    }
    protected virtual void GetMousePos()
    {
        this.mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        this.mouseWorldPos.z = 0;
    }
}
