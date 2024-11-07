using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMoveInputUIManager : MySingleton<PlayerMoveInputUIManager>
{
    [SerializeField] protected List<Button> buttons = new List<Button>();
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadButton();
    }
    public virtual void SetInput(Button button)
    {
        button.image.color = new Color(0, 1, 1, 1);
        foreach (Button btn in this.buttons)
        {
            if (btn == button) continue;
            btn.image.color = new Color(1, 1, 1, 1);

        }
    }

    protected virtual void LoadButton()
    {
        if (this.buttons.Count > 0) return;
        foreach(Transform child in transform)
        {
            if (!child.GetComponent<Button>()) continue;
            this.buttons.Add(child.GetComponent<Button>()); 
        }
        Debug.LogWarning(transform.name + " LoadButotn", gameObject);
    }

}
