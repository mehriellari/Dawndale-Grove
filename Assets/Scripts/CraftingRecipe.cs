using JetBrains.Annotations;
using UnityEngine;
using System;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;



[CreateAssetMenu(menuName ="Data/Recipe")]
public class CraftingRecipe : ScriptableObject
{
    public List<ItemSlot> elements;
    public ItemSlot output;
}
