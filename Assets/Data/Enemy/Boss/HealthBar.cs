using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MyMonoBehaviour
{
    [SerializeField] protected Slider healthSlider;
    protected override void OnEnable()
    {
        this.healthSlider.value = 1f;
    }
    public virtual void ReduceSliderValue(int currentHp,int hpMax)
    {
        this.healthSlider.value = (float)currentHp / hpMax;
    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadHealthSlider();
    }
    protected virtual void LoadHealthSlider()
    {
        if (this.healthSlider != null) return;
        this.healthSlider = GetComponentInChildren<Slider>();
        Debug.LogWarning(transform.name + ": LoadHealthSlider", gameObject);
    }

}
