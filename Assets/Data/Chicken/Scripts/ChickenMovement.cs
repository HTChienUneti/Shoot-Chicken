using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenMovement : MyMonoBehaviour
{
    [SerializeField] protected float speed = 4f;
    [SerializeField] protected Vector3 targetPoint;


    protected override void OnEnable()
    {
        base.OnEnable();
        this.targetPoint = ChickenPointSpawner.Instance.GetPoint();
    }
    protected virtual void FixedUpdate()
    {
        this.Moving();
    }
    protected virtual void Moving()
    {
        if (transform.parent == null)
        {
            Debug.LogWarning(transform.name + ": have no a parent", gameObject);
        }
        if (targetPoint == null) return;
        Vector3 lerp = Vector3.Lerp(transform.parent.position, this.targetPoint,this.speed * Time.fixedDeltaTime);
        transform.parent.position = lerp;

    }
}
