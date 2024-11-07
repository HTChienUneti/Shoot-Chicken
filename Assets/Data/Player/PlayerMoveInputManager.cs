using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMoveInputManager : MySingleton<PlayerMoveInputManager>
{
    [SerializeField] protected List<ObjParentMovement> inputs = new List<ObjParentMovement>();
    protected override void LoadComponent()
    {
        PlayerCtrl player = Transform.FindAnyObjectByType<PlayerCtrl>();
        foreach (Transform child in player.transform)
        {
            if (!child.GetComponent<ObjParentMovement>()) continue;
            this.inputs.Add(child.GetComponent<ObjParentMovement>());
        }
    }
    public virtual void SetInput(ObjParentMovement objParentMovement)
    {
        objParentMovement.gameObject.SetActive(true);
        foreach (ObjParentMovement input  in this.inputs)
        {
            if (input == objParentMovement) continue;
            input.gameObject.SetActive(false);

        }
    }
}
