using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarningText : TextBase
{
    protected override void Start()
    {
        base.Start();
        SpawnChickenManager.Instance.OnWaveChanged += SpawnChickenManager_OnWaveChanged;
        this.text.text = "Mission "+SpawnChickenManager.Instance.Mission + " Wave " + (SpawnChickenManager.Instance.CurrentWave+1);
    }

    private void SpawnChickenManager_OnWaveChanged(object sender, SpawnChickenManager.OnWaveChangeEventArgs e)
    {
        this.text.text = "Mission " + SpawnChickenManager.Instance.Mission + " Wave " + (e.wave+1);
    }
}
