using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Store : Interactable
{
    public ItemContainer storeContent;
    public float buyFromPlayerMultip = 0.5f;
    public float sellToPlayerMultip = 1.5f;

    //intercting with the store opens the store panel in inventory
    public override void Interact(Character character)
    {
        Trading trading = character.GetComponent<Trading>();

        if(trading == null) { return; }

        trading.BeginTrading(this);
    }
}
