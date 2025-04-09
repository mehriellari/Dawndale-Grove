using System;
using Unity.VisualScripting;
using UnityEngine;

public class Trading : MonoBehaviour
{
    [SerializeField] GameObject storePanel;
    [SerializeField] GameObject inventoryPanel;
    [SerializeField] GameObject storeShow;
    [SerializeField] GameObject toolbarPanel;
    [SerializeField] ItemContainer playerInventory;
    [SerializeField] ItemPanel inventoryItemPanel;
  
    Store store;

    Currency money;

    StorePanelScript storePanelScript;

 private void Awake()
    {
        money = GetComponent<Currency>();
        storePanelScript = storePanel.GetComponent<StorePanelScript>();
    }

    //to make store panel show up when accessing store
    public void BeginTrading(Store store)
    {
        this.store = store;

        Debug.Log("trading");

        
        storePanelScript.SetInventory(store.storeContent);

        inventoryPanel.SetActive(true);
       
        storePanel.SetActive(true);

        storeShow.SetActive(true);

        toolbarPanel.SetActive(false);

        
    } 
    
    //for buying items and checking if they can be afforded
    internal void BuyItem(int id)
    {
        Item itemToBuy = store.storeContent.slots[id].item;
        int totalPrice = (int)(itemToBuy.price * store.sellToPlayerMultip);
        if(money.Check(totalPrice) == true)
        {
            money.Decrease(totalPrice);
            playerInventory.Add(itemToBuy);
            inventoryItemPanel.Show();
        }
    }

    //closing the trading panel
    public void StopTrading()
    {
        store = null;
        storePanel.SetActive(false);
        storeShow.SetActive(false);
        inventoryPanel.SetActive(false);
        toolbarPanel.SetActive(true);
    }

    //for selling items and multiplying money if selling stack
    public void SellItem()
    {
        if (GameManager.instance.dragAndDropController.CheckForSale() == true)
        {
            ItemSlot itemToSell = GameManager.instance.dragAndDropController.itemSlot;
            int moneyGain = itemToSell.item.stackable == true ? (int)(itemToSell.item.price * itemToSell.count * store.buyFromPlayerMultip): (int)(itemToSell.item.price * store.buyFromPlayerMultip);
            money.Add(moneyGain);
            itemToSell.Clear();
            GameManager.instance.dragAndDropController.UpdateIcon();
           
        }
    }

   
}


