using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(menuName ="Data/RecipeList")]
public class RecipeList : ScriptableObject
{
    public List<CraftingRecipe> recipes;
}
