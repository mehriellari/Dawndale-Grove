using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;

public class Currency : MonoBehaviour
{
    [SerializeField] int amount;
    [SerializeField] TMPro.TextMeshProUGUI text;

    
    //updating the text when money is gained or lost
    private void Start()
    {
        amount = 100;
        UpdateText();
    }

    //for displaying how much money you have
    private void UpdateText()
    {
        text.text = amount.ToString();
    }

    //for adding money when selling items
    public void Add(int moneyGain)
    {
        amount += moneyGain;
        UpdateText();
    }

    //for checking if you can afford an object
    internal bool Check(int totalPrice)
    {
        return amount >= totalPrice;
    }

    //for removing money once you buy an item
    internal void Decrease(int totalPrice)
    {
        amount -= totalPrice;
        if(amount < 0)
        {
            amount = 0;
        }
        UpdateText();
    }
}
