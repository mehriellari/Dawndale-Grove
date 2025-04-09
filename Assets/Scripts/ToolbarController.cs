using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class ToolbarController : MonoBehaviour
{
    [SerializeField] int toolbarSize = 5;
    int selectedTool;

    //for changing highlight with scroll wheel
    public Action<int> onChange;

    //for tools
    public Item GetItem
    {
        get
        {
            return GameManager.instance.inventoryContainer.slots[selectedTool].item;
        }
    }

    //for detecting the scroll wheel and making sure it loops within the size of the toolbar
    private void Update()
    {
        float delta = Input.mouseScrollDelta.y;
        if(delta != 0)
        {
            if(delta > 0)
            {
                selectedTool += 1;
                selectedTool = (selectedTool >= toolbarSize ? 0 : selectedTool);
            }
            else
            {
                selectedTool -= 1;
                selectedTool = (selectedTool <= 0 ? toolbarSize - 1 : selectedTool);
            }
            onChange?.Invoke(selectedTool);
        }
    } internal void Set(int id)
    {
        selectedTool = id;
    }
}
