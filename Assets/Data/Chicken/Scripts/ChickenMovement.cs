using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ChickenMovement : MyMonoBehaviour,IChickenMoveState
{
    [SerializeField] protected float speed = 5f;
    [SerializeField] protected List<PointSO>points = new List<PointSO>();
    [SerializeField] protected int currentWaypointIndex = 0;
    [SerializeField] protected bool isMoveEnter = true;
    [SerializeField] protected Vector3 direction = Vector3.left;
    [SerializeField] protected float boundX = 8f;

    public enum State
    {
        Idel,
        MoveEnter,
        MoveAround
    }
    [SerializeField] protected State state = State.MoveEnter;
    protected override void OnEnable()
    {
        ChickenPoint.Instance.AddChicken(this);
        foreach (var point in ChickenPoint.Instance.Points)
        {
            points.Add(point);
        }
        ChickenPoint.Instance.RemoveLastPoint();
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        this.points.Clear();
        this.currentWaypointIndex = 0;
        ChickenPoint.Instance.RemoveChicken(this);
    }
    protected virtual void  FixedUpdate()
    {
        this.Moving();
       
    }  
    protected virtual void Moving()
    {

        if (this.points.Count == 0) return;
        switch (this.state)
        {
            case State.Idel:
                    break;
            case State.MoveEnter:
                this.MoveEnter();
                break;
            case State.MoveAround:
                this.MoveAround();
                break;
        }
    }
    protected virtual void MoveAround()
    {
        transform.parent.Translate(direction * this.speed* Time.fixedDeltaTime);
        if(transform.parent.position.x <= -this.boundX)
        {
            this.direction = Vector3.right;
        }
        else if(transform.parent.position.x >= this.boundX)
        {
            this.direction = Vector3.left;
        }
    }
    protected virtual void MoveEnter()
    {
        if (currentWaypointIndex == this.points.Count) return;
        Vector3 target = points[currentWaypointIndex].point;

        transform.parent.position = Vector3.MoveTowards(transform.parent.position, target, speed * Time.deltaTime);

        if (Vector3.Distance(transform.parent.position, target) < 0.1f)
        {
            currentWaypointIndex++;
        }
    }

    void IChickenMoveState.MoveAround()
    {
        this.state = State.MoveAround;
    }
}
