using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="ChickenSO",menuName = "SO/ChickenSO")]
public class ChickenSO : ScriptableObject
{
    public ChickenCode ChickenCode;
    public string chickenName;
    public List<ItemDrop> itemDrop;
    public int maxHp = 1;

    static private ChickenSO _instance;
    static public ChickenSO Instance
    {
        get
        {
            if(_instance == null)
            {
                string path = "SO/Chicken/Chicken_1";
                _instance = Resources.Load<ChickenSO>(path);
            }
            if(_instance == null)
            {
                Debug.LogError("ChickenSO not found in Resources");
            }
            return _instance; 
        } 
    }


    public virtual void AddHp(int hp)
    {
        this.maxHp += hp;
    }
}
