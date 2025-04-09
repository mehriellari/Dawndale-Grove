using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
using System;

public class InventoryButton : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] Image icon;
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] Image highlight;

    int myIndex;

    ItemPanel itemPanel;

    public void SetIndex(int index)
    {
        myIndex = index;
    }

    public void SetItemPanel(ItemPanel source)
    {
        itemPanel = source;
    }

    //Putting items in the inventory slots and checking if they can stack or not
    public void Set(ItemSlot slot)
    {
        icon.gameObject.SetActive(true);
        icon.sprite = slot.item.icon;

        if(slot.item.stackable == true)
        {
            text.gameObject.SetActive(true);
            text.text = slot.count.ToString();
        }
        else
        {
            text.gameObject.SetActive(false);
        }
    }

    //making the slot empty if theres no object in it
    public void Clean()
    {
        icon.sprite = null;
        icon.gameObject.SetActive(false);

        text.gameObject.SetActive(false);
    }

    
    public void OnPointerClick(PointerEventData eventData)
    {
        
        itemPanel.OnClick(myIndex);
    }

    //for highlighting toolbar selector
    public void Highlight(bool b)
    {
        highlight.gameObject.SetActive(b);
    }
}
