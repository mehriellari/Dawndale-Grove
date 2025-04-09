using UnityEngine;


[CreateAssetMenu(menuName ="Data/Tool Action/Seed Tile")]
public class SeedTile : ToolAction
{

    //for seeding a plot that is already plowed
    public override bool OnApplyToTileMap(Vector3Int gridPosition, TilemapController tilemapController, Item item)
    {
        if(tilemapController.cropsManager.Check(gridPosition) == false)
        {
            return false;
        }


        tilemapController.cropsManager.Seed(gridPosition, item.crop);

        return true;
    }

    //for removing used seeds after placing them in dirt
    public override void OnItemUsed(Item usedItem, ItemContainer inventory)
    {
        inventory.Remove(usedItem);
    }
}
