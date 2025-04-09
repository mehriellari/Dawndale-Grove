using System;
using JetBrains.Annotations;
using NUnit.Framework;
using Unity.VisualScripting;
using UnityEngine;

[Serializable]
public class ItemSlot
{
    public Item item;
    public int count;


    //for drag and drop: copying items and placing them and clearing the old slot
    public void Copy(ItemSlot slot)
    {
        item = slot.item;
        count = slot.count;
    }

    public void Set(Item item, int count)
    {
        this.item = item;
        this.count = count;
    }

    public void Clear()
    {
        item = null; 
        count = 0;
        
    }
}

[CreateAssetMenu(menuName ="Data/Item Container")]
public class ItemContainer : ScriptableObject
{
    public System.Collections.Generic.List<ItemSlot> slots;
    public bool isDirty;

    //adding items to inventory
    public void Add(Item item, int count = 1)
    {
        isDirty = true;

        if(item.stackable == true)
        {
            ItemSlot itemSlot = slots.Find(x => x.item == item);
            if (itemSlot != null)
            {
                itemSlot.count += count;
            }
            else
            {
                itemSlot = slots.Find(x => x.item == null);
                if (itemSlot != null)
                {
                    itemSlot.item = item;
                    itemSlot.count = count;
                }
            }
        }
        else
        {
            //non stackable item adding
            ItemSlot itemSlot = slots.Find(x => x.item == null);
            if(itemSlot == null)
            {
                itemSlot.item = item;
            }
        }
    }

    //for removing items from inventory when they are used such as seeds into dirt
    public void Remove(Item itemToRemove, int count = 1)
    {
        isDirty = true;

        if(itemToRemove.stackable)
        {
            ItemSlot itemSlot = slots.Find(x => x.item == itemToRemove);
            if (itemSlot == null) { return; }

            itemSlot.count -= count;
            if(itemSlot.count < 0)
            {
                itemSlot.Clear();
            }
        }
        else
        {
            while(count >0)
            {
                count -= 1;

                ItemSlot itemSlot = slots.Find(x => x.item == itemToRemove);
                if(itemSlot == null) { return; }

                itemSlot.Clear();
            }
        }

    }

    //for checking if there is free space in the inventory to craft and place it in there
    internal bool CheckFreeSpace()
    {
        for(int i = 0; i < slots.Count; i++)
            {
            if (slots[i].item == null)
            {
                return true;
            }
        }
        return false;
    }

    //check for slots
    internal bool CheckItem(ItemSlot checkingItem)
    {
        ItemSlot itemSlot = slots.Find(x => x.item == checkingItem.item);

        if (itemSlot == null) { return false; }
       
        if (checkingItem.item.stackable) { return itemSlot.count > checkingItem.count; }

        return true;
    }
}
