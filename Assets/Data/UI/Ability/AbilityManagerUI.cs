using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class AbilityManagerUI : MyMonoBehaviour, IUsingInventory
{
    [SerializeField] protected List<AbilityUI> abilities;
    protected override void Start()
    {
        base.Start();
        PlayerCtrl.Instance.Inventory.AddListener(this);
    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadAbilities();
    }
    protected virtual void LoadAbilities()
    {
        if (this.abilities.Count != 0) return;
        foreach(Transform child in transform)
        {
            this.abilities.Add(child.GetComponent<AbilityUI>());
        }
        Debug.LogWarning(transform.name + ": loadAbilities", gameObject);
    }

    public void OnInventoryChanged(List<ItemInventory> inventoryItem)
    {
        foreach(AbilityUI ability in this.abilities)
        {
            ability.OnInventoryChanged(inventoryItem);
        }    
    }
}
