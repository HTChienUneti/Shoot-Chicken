using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ShooterLevel : MyMonoBehaviour
{
    [SerializeField] protected int currentLevel = 1;
    [SerializeField] protected int maxLevel = 10;
    public int CurrentLevel
    {
        set { currentLevel = value; }
        get { return currentLevel; }
    }
    public virtual void LevelUp(ItemTypePowerup itemTypeAdd, int level)
    {
        if (itemTypeAdd == ItemTypePowerup.Plus)
        {
            this.currentLevel += level;
        }
        if (itemTypeAdd == ItemTypePowerup.Time)
        {
            this.currentLevel *= level;
        }
       
        if (this.currentLevel > this.maxLevel) this.currentLevel = this.maxLevel;
    }
    public virtual void LevelDown(int level)
    {
        this.currentLevel -= level;
       
    }

}
