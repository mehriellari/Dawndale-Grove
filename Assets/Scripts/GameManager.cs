using UnityEngine;

public class GameManager : MonoBehaviour
{
    //this script is for managing the whole game including the drag and drop controller and item container
    public static GameManager instance;

    private void Awake()
    {
        instance = this;
    }

    public GameObject player;
    public ItemContainer inventoryContainer;
    public ItemDragAndDropController dragAndDropController;
    public DayTimeController timeController;
}
