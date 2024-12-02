using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class AbilityUI : ButtonBase//, IUsingInventory
{
    [SerializeField] protected Image highlightImage;
    [SerializeField] protected TextMeshProUGUI countText;
    [SerializeField] protected Ability ability;
    [SerializeField] protected Color buttonOnColor = new Color(1, 1, 1, 1);
    [SerializeField] protected Color buttonOffColor = new Color(1, 1, 1, .2f);
    protected override void Start()
    {
        base.Start();
        //   PlayerCtrl.Instance.Inventory.AddListener(this);
        this.button.image.color = buttonOffColor;
    }
    protected override void LoadComponent()
    {
        this.LoadAbility();
        base.LoadComponent();
        this.LoadHighlightImage();
        this.LoadCountText();

    }
    protected virtual void LoadAbility()
    {
        if (this.ability != null) return;
        string path = "SO/Ability/" + transform.name;
        this.ability = Resources.Load<Ability>(path);
        Debug.LogWarning(transform.name + " :LoadAbility", gameObject);
    }
    protected override void LoadButton()
    {
        if(this.button != null) return;
        this.button  = GetComponentInChildren<Button>();
        this.button.image.sprite = this.ability.sprite;
        Debug.LogWarning(transform.name + ": LoadButton", gameObject);
    }
    protected virtual void LoadHighlightImage()
    {
        if(this.highlightImage != null) return;
        this.highlightImage = transform.Find("HighlightImage").GetComponent<Image>();
        this.highlightImage.gameObject.SetActive(false);
        Debug.LogWarning(transform.name + ": LoadSprite", gameObject);
    }
    protected virtual void LoadCountText()
    {
        if (this.countText != null) return;
        this.countText = GetComponentInChildren<TextMeshProUGUI>();
        Debug.Log(transform.name + ": LoadCountText", gameObject);
    }

    public void OnInventoryChanged(List<ItemInventory> inventoryItem)
    {
        int avaiableCnt = this.AvailableCount(inventoryItem);
        if (avaiableCnt >0)
        {
            this.button.image.color = this.buttonOnColor;
        }
        else
        {
            this.button.image.color = this.buttonOffColor;
        }
        this.countText.text = this.AvailableCount(inventoryItem).ToString();
    }
    protected virtual int AvailableCount(List<ItemInventory> inventoryItem)
    {
        int cnt = 0;
        foreach (ItemRequire item in this.ability.requires)
        {
            foreach (ItemInventory itemInventory in inventoryItem)
            {
                if (itemInventory.itemSO != item.itemSO) continue;
                if (itemInventory.stack < item.count) return 0;
                cnt = itemInventory.stack / item.count;
                break;
            }            
        }
        return cnt;
    }
    public void Countdown(float countdown, float timeDelay)
    {
        this.highlightImage.gameObject.SetActive(false);
        this.button.image.fillAmount = countdown / timeDelay;
    }

    public void Using(float time, float TimeUse)
    {
        this.highlightImage.gameObject.SetActive(true);
    }
   
}
