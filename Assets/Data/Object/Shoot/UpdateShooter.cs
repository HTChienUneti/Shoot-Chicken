using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UpdateShooter : MyMonoBehaviour
{
    [SerializeField] protected int currentLevel = 1;
    [SerializeField] protected int maxLevel = 10;
    public int CurrentLevel
    {
        set { currentLevel = value; }
        get { return currentLevel; }
    }
    public virtual void Upgrade(ItemPower itemPower)
    {
        this.currentLevel += itemPower.power;
    }
}
