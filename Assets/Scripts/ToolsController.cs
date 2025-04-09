using System;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ToolsController : MonoBehaviour
{
    //to make adjustable fields to change interact distance to an object to use a tool on
    Movement2 character;
    Rigidbody2D rb;
    ToolbarController toolbarController;
    [SerializeField] float offsetDistance = 1f;
    [SerializeField] float sizeOfInteractableArea = 0.5f;
    [SerializeField] MarkerManager markerManager;
    [SerializeField] TilemapController tilemapController;
    [SerializeField] float maxDistance = 1f;
    [SerializeField] ToolAction onTilePickUp;

    Vector3Int selectedTilePosition;
    bool selectable;

    private void Awake()
    {
        character = GetComponent<Movement2>();
        rb = GetComponent<Rigidbody2D>();
        toolbarController = GetComponent<ToolbarController>();
    }

    //code to have tool use be a click
    //checks if tile can be selected
    private void Update()
    {
        SelectTile();
        CanSelectCheck();
        Marker();
        if (Input.GetMouseButtonDown(0))
        {
            if(UseToolWorld() == true)
            {
                return;
            }
            UseToolGrid();
        }
    }

    private void SelectTile()
    {
        selectedTilePosition = tilemapController.GetGridPosition(Input.mousePosition, true);
    }

    void CanSelectCheck()
    {
        Vector2 characterPosition = transform.position;
        Vector2 cameraPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        selectable = Vector2.Distance(characterPosition, cameraPosition) < maxDistance;
        markerManager.Show(selectable);
    }

    //for marking spots on the grid
    private void Marker()
    {
        markerManager.markedCellPosition = selectedTilePosition;
    }

    //tools can only be used on objects the player is facing but not to ones with their back turned to it
    //also the distance to the object collider and player collider
    //for using tools on things in the world and not on the grid
    private bool UseToolWorld()
    {
        Vector2 position = rb.position + character.lastMotionVector * offsetDistance;

        Item item = toolbarController.GetItem;
        if(item == null) { return false; }
        if(item.onAction == null) { return false; }

        bool complete = item.onAction.OnApply(position);

        if (complete == true)
        {
            if (item.onItemUsed != null)
            {
                item.onItemUsed.OnItemUsed(item, GameManager.instance.inventoryContainer);
            }

        }

        return complete;
    }

    //for using tools on the grid for crops
    private void UseToolGrid()
    {
        if(selectable == true)
        {
            Item item = toolbarController.GetItem;
            if (item == null) 
            {
                PickUptile();
                return;
            }
            if(item.onTileMapAction == null) { return; }

            bool complete = item.onTileMapAction.OnApplyToTileMap(selectedTilePosition, tilemapController, item);

            if (complete == true)
            {
                if(item.onItemUsed != null)
                {
                    item.onItemUsed.OnItemUsed(item, GameManager.instance.inventoryContainer);
                }
                
            }
        }
    }

    private void PickUptile()
    {
        if (onTilePickUp == null) { return; }

        onTilePickUp.OnApplyToTileMap(selectedTilePosition, tilemapController, null);
    }
}
