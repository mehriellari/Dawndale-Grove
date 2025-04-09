using NUnit.Framework;
using UnityEngine;
using UnityEngine.Tilemaps;
using System.Collections.Generic;
using System.Collections;

public class TilemapController : MonoBehaviour
{
    [SerializeField] Tilemap tilemap;
    public CropsManager cropsManager;


    //for locations on the grid
    public Vector3Int GetGridPosition(Vector2 position, bool mousePosition)
    {

        Vector3 worldPosition;

        if (mousePosition)
        {
            worldPosition = Camera.main.ScreenToWorldPoint(position);
        }
        else
        {
            worldPosition = position;
        }

        Vector3Int gridPosition = tilemap.WorldToCell(worldPosition);

        return gridPosition;
    }

    //for tilemaps and their location
    public TileBase GetTileBase(Vector3Int gridPosition)
    { 

        TileBase tile = tilemap.GetTile(gridPosition);

        return tile;
    }

}