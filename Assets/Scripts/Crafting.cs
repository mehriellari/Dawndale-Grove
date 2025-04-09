using UnityEngine;

public class Crafting : MonoBehaviour
{
    [SerializeField] ItemContainer inventory;

    //refusing to craft if there isnt any inventory spaces
    public void Craft(CraftingRecipe recipe)
    {
        if(inventory.CheckFreeSpace() == false)
        {
            Debug.Log("Not enough space");
            return;
        }

        //refusing to craft if there are not enough crafting materials
        for(int i = 0; i < recipe.elements.Count; i++)
        {
            if (inventory.CheckItem(recipe.elements[i]) == false)
            {
                
                Debug.Log("Crafting elements are not present to craft");
                return;
            }
        }
       
        //removing materials and adding new crafted item to inventory
        for(int i = 0; i < recipe.elements.Count;i++)
        {
            inventory.Remove(recipe.elements[i].item, recipe.elements[i].count);
        }
        
        inventory.Add(recipe.output.item, recipe.output.count);
        
    }
}
