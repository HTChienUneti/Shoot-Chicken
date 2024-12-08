using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ShooterLevel : MyMonoBehaviour
{
    [SerializeField] protected int currentLevel = 1;
    [SerializeField] protected int maxLevel = 10;
    protected List<IUsingShooterLevel> listeners = new List<IUsingShooterLevel>();
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
        this.OnChangeLevel();
    }
    public virtual void LevelDown(int level)
    {
        this.currentLevel -= level;
        this.OnChangeLevel();
    }

    public virtual void AddListener(IUsingShooterLevel listener)
    {
        this.listeners.Add(listener);
    }
    public virtual void RemoveListener(IUsingShooterLevel listener)
    {
        this.listeners.Remove(listener);
    }

    public void OnChangeLevel()
    {
        foreach (IUsingShooterLevel listener in this.listeners)
        {
            listener.OnChangeLevel(this.currentLevel);
        }
    }

}
