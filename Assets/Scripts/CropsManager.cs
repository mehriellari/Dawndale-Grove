using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.Tilemaps;

//crops and their tiles
public class CropTile
{
    public int growTimer;
    public int growStage;
    public Crop crop;
    public SpriteRenderer renderer;
    public Vector3Int position;

    //when crops are complete in growing
    public bool Complete
    {
        get
        {
            if (crop == null) { return false; }
            return growTimer >= crop.timeToGrow;
        }
    }

    //for when the crop is harvested to remove the sprite
    internal void Harvested()
    {
        growTimer = 0;
        growStage = 0;
        crop = null;
        renderer.gameObject.SetActive(false);
    }
}

//managing if a tile on grid is plowed or seeded
public class CropsManager : TimeAgent
{
    [SerializeField] TileBase plowed;
    [SerializeField] TileBase seeded;
    [SerializeField] Tilemap targetTilemap;


    [SerializeField] GameObject cropsSpritePrefab;

    Dictionary<Vector2Int, CropTile> crops;

    private void Start()
    {
        crops = new Dictionary<Vector2Int, CropTile>();
        onTimeTick += Tick;
        Init();
    }

    //creating a timer for crop growth
    public void Tick()
    {

        foreach (CropTile cropTile in crops.Values)
        {
            if(cropTile.crop == null) { continue; }

            if (cropTile.Complete)
            {
                Debug.Log("I'm done growing");
                continue;

            }

            cropTile.growTimer += 1;

            if(cropTile.growTimer >= cropTile.crop.growthStageTime[cropTile.growStage])
            {
                cropTile.renderer.gameObject.SetActive(true);
                cropTile.renderer.sprite = cropTile.crop.sprites[cropTile.growStage];

                cropTile.growStage += 1;
                
            }
        }
    }

    public bool Check(Vector3Int position)
    {

        return crops.ContainsKey((Vector2Int)position);
    }

    //to check if a tile is plowed, if it isnt it will plow it
    public void Plow(Vector3Int position)
    {

        if (crops.ContainsKey((Vector2Int)position))
        {
            return;
        }

        CreatePlowedTile(position);
    }

    //for creating a seeded tile
    public void Seed(Vector3Int position, Crop toSeed)
    {

        targetTilemap.SetTile(position, seeded);

        crops[(Vector2Int)position].crop = toSeed;
    }

    //for creating the plowed tile
    private void CreatePlowedTile(Vector3Int position)
    { 

        CropTile crop = new CropTile();
        crops.Add((Vector2Int)position, crop);

        GameObject go = Instantiate(cropsSpritePrefab);
        go.transform.position = targetTilemap.CellToWorld(position);
        go.transform.position -= Vector3.forward * 0.01f;
        go.SetActive(false);
        crop.renderer = go.GetComponent<SpriteRenderer>();

        targetTilemap.SetTile(position, plowed);
    }

    //for picking up crops when they are done growing and assigning it to be harvested which hides sprite
    internal void PickUp(Vector3Int gridPosition)
    {

        Vector2Int position = (Vector2Int)gridPosition;
        if(crops.ContainsKey(position) == false) { return; }

        CropTile cropTile = crops[position];

        if(cropTile.Complete)
        {
            ItemSpawnManager.instance.SpawnItem(targetTilemap.CellToWorld(gridPosition),
                cropTile.crop.yield,
                cropTile.crop.count
                );

            targetTilemap.SetTile(gridPosition, plowed);
            cropTile.Harvested();
        }
    }
}
