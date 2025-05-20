using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionDataManager : MySingleton<MissionDataManager>
{
    [SerializeField] protected MissionSO missionSO;
    public MissionSO Mission
    {
        get => this.missionSO;
        set => this.missionSO = value;
    }
    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
    }

}
