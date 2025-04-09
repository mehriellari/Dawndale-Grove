using UnityEngine;

[CreateAssetMenu(menuName ="Data/Item")]
public class Item : ScriptableObject
{
    //this is to add any item to game and assign it a name and icon and select if its stackable
    public string Name;
    public bool stackable;
    public Sprite icon;
    public ToolAction onAction;
    public ToolAction onTileMapAction;
    public ToolAction onItemUsed;
    public Crop crop;
    public int price = 10;
    public bool canBeSold = true;

}
