using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(menuName ="Data/Tool Action/Harvest")]
public class OnTilePickAction : ToolAction
{
    

    //for picking up finished crops with hands
    public override bool OnApplyToTileMap(Vector3Int gridPosition, TilemapController tilemapController, Item item)
    {
        TileBase tileToPlow = tilemapController.GetTileBase(gridPosition);

        tilemapController.cropsManager.PickUp(gridPosition);

       

        return true;
    }


}
