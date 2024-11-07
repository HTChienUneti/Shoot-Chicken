using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderPowerBulletAbilityUI : MyMonoBehaviour, IUsingBulletAbility
{
    [SerializeField] protected Slider slider;
    protected override void Start()
    {
        base.Start();
        AbilityBulletManager.Instance.AddListener(this);
        gameObject.SetActive(false);
    }
    public void Using(float time,float timeUse)
    {
        gameObject.SetActive(true);
        this.slider.value = time/timeUse;   
        if(this.slider.value <=0 )
            gameObject.SetActive(false);
    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadSlider();
    }
    protected virtual void LoadSlider()
    {
        if (this.slider != null) return;
        this.slider = GetComponent<Slider>();
        Debug.Log(transform.name + ": LoadSlider", gameObject);
    }

    public void Countdown(float countdown, float timeDelay)
    {
        gameObject.SetActive(false);
    }
}
