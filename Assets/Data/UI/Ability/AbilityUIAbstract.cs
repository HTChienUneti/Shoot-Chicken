using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;
public abstract class AbilityUIAbstract : MyMonoBehaviour, IUsingInventory
{
    [SerializeField] protected Image image;
    [SerializeField] protected Image highlightImage;
    [SerializeField] protected TextMeshProUGUI countText;
    [SerializeField] protected DamagingSO damagingSO;
    protected override void Start()
    {
        base.Start();
        PlayerCtrl.Instance.Inventory.AddListener(this);
        this.image.color = new Color(1, 1, 1, 0.2f);

    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadDamagingSO();
        this.LoadSprite();
        this.LoadCountText();

    }
    protected virtual void LoadDamagingSO()
    {
        if (this.damagingSO != null) return;
        string path = "SO/Damaging/" + transform.name;
        this.damagingSO = Resources.Load<DamagingSO>(path);
        Debug.LogWarning(transform.name + " :LoadDamagingSO", gameObject);
    }
    protected virtual void LoadSprite()
    {
        if (this.image != null) return;
        this.image = transform.Find("Sprite").GetComponent<Image>();
        this.highlightImage = transform.Find("HightlightImage").GetComponent<Image>();
        this.image.sprite = this.damagingSO._sprite;
        Debug.Log(transform.name + ": LoadSprite", gameObject);
    }
    protected virtual void LoadCountText()
    {
        if (this.countText != null) return;
        this.countText = GetComponentInChildren<TextMeshProUGUI>();
        Debug.Log(transform.name + ": LoadCountText", gameObject);
    }

    public void OnInventoryChanged(List<ItemInventory> inventoryItem)
    {
        if (this.HaveEnoughItem(inventoryItem))
        {
            //    this.countText.text = (item.stack / this.damagingSO.requireCount).ToString();
            this.image.color = new Color(1, 1, 1, 1);
        }
        else
        {
            this.image.color = new Color(1, 1, 1, 0.2f);
        }

    }
    protected virtual bool HaveEnoughItem(List<ItemInventory> inventoryItem)
    {
        
        foreach (Ingredient ingredient in this.damagingSO.ingredients)
        {
            bool isContain = false;
            foreach (ItemInventory itemInventory in inventoryItem)
            {
                if (itemInventory.itemProfile != ingredient.profile) continue;
                if (itemInventory.stack < ingredient.count) continue;
                isContain = true;
            }
            if (!isContain) return false;
        }
        return true;
    }
    public void Countdown(float countdown, float timeDelay)
    {
        this.highlightImage.gameObject.SetActive(false);
        this.image.fillAmount = countdown / timeDelay;
    }

    public void Using(float time, float TimeUse)
    {
        this.highlightImage.gameObject.SetActive(true);
    }
}
