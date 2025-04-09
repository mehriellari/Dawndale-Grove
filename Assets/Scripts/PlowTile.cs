using NUnit.Framework;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Tilemaps;

[CreateAssetMenu(menuName = "Data/Tool Action/Plow")]
public class PlowTile : ToolAction
{
    [SerializeField] List<TileBase> canPlow;
    [SerializeField] AudioClip onPlowUsed;
    

    //seeing if ground can be plowed or not
    //if it can it does but if it is already plowed it cant
    public override bool OnApplyToTileMap(Vector3Int gridPosition, TilemapController tilemapController, Item item)
    {
        TileBase tileToPlow = tilemapController.GetTileBase(gridPosition);

        if (canPlow.Contains(tileToPlow) == false)
        {
            return false;
        }

        tilemapController.cropsManager.Plow(gridPosition);

        AudioManager.instance.Play(onPlowUsed);

        return true;

    }
}
