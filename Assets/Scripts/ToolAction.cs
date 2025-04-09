using UnityEngine;

//tool actions for objects, tilemap(crops), and inventory items
public class ToolAction : ScriptableObject 
{
    public virtual bool OnApply(Vector2 worldPoint)
    {
        Debug.LogWarning("OnApply is not implemented");
        return true;
    }

    public virtual bool OnApplyToTileMap(Vector3Int gridPosition, TilemapController tilemapController, Item item)
    {
        Debug.LogWarning("OnApplytToTileMap is not implemented");
        return true;
    }

    public virtual void OnItemUsed(Item usedItem, ItemContainer inventory)
    {
        
    }
}
