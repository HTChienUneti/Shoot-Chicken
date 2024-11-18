using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCtrl : DamagingObjCtrl
{
    public virtual void SetModel(Sprite sprite)
    {
        this.model.sprite = sprite;
    }

}
