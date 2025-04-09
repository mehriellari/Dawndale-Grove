using UnityEngine;

public class RecipePanel : ItemPanel
{
    [SerializeField] RecipeList recipeList;
    [SerializeField] Crafting crafting;

    //showing the crafting recipes on the buttons on the panel
    public override void Show()
    {
        for(int i = 0; i < buttons.Count && i < recipeList.recipes.Count; i++)
        {
            buttons[i].Set(recipeList.recipes[i].output);
        }
    }

    //crafting a recipe when the button is clicked
    public override void OnClick(int id)
    {
        if (id >= recipeList.recipes.Count) { return; }

        crafting.Craft(recipeList.recipes[id]);

        
    }
}
