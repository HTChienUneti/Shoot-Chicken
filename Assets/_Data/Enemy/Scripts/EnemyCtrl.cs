using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Jobs;
    
public class EnemyCtrl : DamagingObjCtrl
{
    [SerializeField] protected EnemyMovement enemyMovement;
    public EnemyMovement EnemyMovement => enemyMovement;
    [SerializeField] protected EnemySO enemySO;
    public EnemySO EnemySO => enemySO;
    [SerializeField] protected Transform model;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadEnemyMovement();
        this.LoadModel();
        this.LoadEnemySO();
    }

    protected virtual void LoadModel()
    {
        if (this.model != null) return;
        this.model = transform.Find("Model");
        Debug.LogWarning(transform.name + ": LoadModel", gameObject);
    }
    protected virtual void LoadEnemySO()
    {
        if (this.EnemySO!= null) return;
        string path = "SO/Enemy/"+transform.name+"/"+transform.name;
        this.enemySO = Resources.Load<EnemySO>(path);
        this.model.GetComponent<MeshRenderer>().material = this.enemySO.EnemyProfile.material;
        this.model.GetComponent<MeshFilter>().mesh = this.enemySO.EnemyProfile.mesh;
     //   Instantiate(this.enemySO.EnemyProfile.prefab).parent = transform;
        Debug.LogWarning(transform.name + ": LoadEnemySO", gameObject);
    }
    protected virtual void LoadEnemyMovement()
    {
        if (this.enemyMovement != null) return;
        this.enemyMovement = GetComponentInChildren<EnemyMovement>();
        Debug.LogWarning(transform.name + ": LoadEnemyMovement", gameObject);
    }
}
