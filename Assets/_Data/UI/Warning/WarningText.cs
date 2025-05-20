using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarningText : TextBase
{
    protected override void Start()
    {
        base.Start();
        SpawnEnemyManager.Instance.OnWaveChanged += SpawnChickenManager_OnWaveChanged;
        this.text.text = "Mission "+SpawnEnemyManager.Instance.Mission + " Wave " + (SpawnEnemyManager.Instance.CurrentWave+1);
    }

    private void SpawnChickenManager_OnWaveChanged(object sender, SpawnEnemyManager.OnWaveChangeEventArgs e)
    {
        this.text.text = "Mission " + SpawnEnemyManager.Instance.Mission+ " Wave " + (e.wave+1);
    }
}
