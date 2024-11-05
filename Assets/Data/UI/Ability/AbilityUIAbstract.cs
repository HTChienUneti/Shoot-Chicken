using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public abstract class AbilityUIAbstract : MyMonoBehaviour,IUsingInventory
{
    [SerializeField] protected Image image;
    [SerializeField] protected Image highlightImage;
    [SerializeField] protected TextMeshProUGUI countText;
    protected override void Start()
    {
        base.Start();
        PlayerCtrl.Instance.Inventory.AddListener(this);
    
    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadSprite();
        this.LoadCountText();
    }
    protected virtual void LoadSprite()
    {
        if (this.image != null) return;
        this.image = transform.Find("Sprite").GetComponent<Image>();
        this.highlightImage = transform.Find("HightlightImage").GetComponent<Image>();
        Debug.Log(transform.name + ": LoadSprite", gameObject);
    }
    protected virtual void LoadCountText()
    {
        if (this.countText != null) return;
        this.countText = GetComponentInChildren<TextMeshProUGUI>();
        Debug.Log(transform.name + ": LoadCountText", gameObject);
    }

    public void OnInventoryChanged(List<InventoryItem> inventoryItem)
    {
        foreach (InventoryItem item in inventoryItem)
        {
            if (item.itemDrop.itemCode.ToString() != transform.name) continue;
            this.countText.text = item.stack.ToString();
        }
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
