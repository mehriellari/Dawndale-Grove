using System;
using UnityEngine;

public class StorePanelScript : ItemPanel
{
    [SerializeField] Trading trading;

    //clicking on store slots with objects buys them and clicking on empty slots sells the item you are holding
    public override void OnClick(int id)
    {
        if(GameManager.instance.dragAndDropController.itemSlot.item == null)
        {
            BuyItem(id);
        }
        else
        {
            SellItem();
        }

            SellItem();
        Show();
    }

    private void BuyItem(int id)
    {
        trading.BuyItem(id);
    }

    private void SellItem()
    {
        trading.SellItem();
    }
    
   
}
