using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenMovement : MyMonoBehaviour
{
    [SerializeField] protected float speed = 4f;
    [SerializeField] protected Point targetPoint;


    protected override void OnEnable()
    {
        base.OnEnable();
        foreach(Point point in ChickenPoint.Instance.Points)
        {
            if (point.isUsed) continue;
            this.targetPoint = point;
            point.isUsed = true;
            break;
        }
    }
    private void OnDisable()
    {
        this.targetPoint.isUsed = false;
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
        Vector3 lerp = Vector3.Lerp(transform.parent.position, this.targetPoint.point,this.speed * Time.fixedDeltaTime);
        transform.parent.position = lerp;

    }
}
