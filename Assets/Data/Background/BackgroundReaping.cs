using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundReaping : MyMonoBehaviour
{
    [SerializeField] protected float boundY = -40;
    [SerializeField] protected float speed = 5f;
    [SerializeField] protected Vector3 defaultPos = new Vector3(0,15,0);
    public virtual void SetSpeed(float speed)
    {
        this.speed = speed;
    }
    private void FixedUpdate()
    {
        transform.Translate(Vector3.down * this.speed * Time.fixedDeltaTime);
        if(transform.position.y <= this.boundY)
        {
            transform.position = this.defaultPos;
        }
    }
}
