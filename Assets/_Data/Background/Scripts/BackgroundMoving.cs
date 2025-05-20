//using System.Collections;
//using System.Collections.Generic;
//using UnityEditor;
//using UnityEngine;

//public class BackgroundMoving : MyMonoBehaviour
//{
//    [SerializeField] protected BackgroundCtrl backgroundCtrl;
//    [SerializeField] protected float posY;
//    bool isSpawn = false;
//    public float speed = 2f;
//    public float offset = 2f;
//    public Material mat;
//    protected override void OnEnable()
//    {
//        base.OnEnable();
//        this.isSpawn = false;
//        this.mat =GetComponent<SpriteRenderer>().material;
//    }
//    private void Update()
//    {
//        offset += (Time.deltaTime * speed) / 10f;
//        mat.SetTextureOffset("_MainTex", new Vector2(0, offset));
//    }
//    protected override void LoadComponent()
//    {
//        base.LoadComponent();
//        this.LoadBackgroundCtrl();
//    }
//    protected virtual void LoadBackgroundCtrl()
//    {
//        if (this.backgroundCtrl != null) return;
//        this.backgroundCtrl = transform.parent.GetComponent<BackgroundCtrl>();
//        Debug.LogWarning(transform.name + ": LoadBackgroundCtrl", gameObject);
//    }
//    //protected override void Moving()
//    //{
//    //    base.Moving();
//    //    if (transform.parent.position.y <= this.posY && !this.isSpawn)
//    //    {
//    //        this.backgroundCtrl.SpawnBackground.Spawn();
//    //        this.isSpawn = true;
//    //    }
//    //}
//    //protected override void GetTargetPos()
//    //{
//    //    this.targetPos = transform.parent.position + Vector3.down;
//    //}
//}
