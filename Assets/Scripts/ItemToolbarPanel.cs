using UnityEngine;

//this script is inheiriting from the item panel which is a copy of the inventory panel but will be changed so it cant click and drag
//is a scroll wheel and selector panel instead
public class ItemToolbarPanel : ItemPanel
{
    [SerializeField] ToolbarController toolbarController;

    //for changing highlight with scroll wheel
    private void Start()
    {
        Init();
        toolbarController.onChange += Highlight;
        Highlight(0);
    }

    //for changing toolbar highlight with click
    public override void OnClick(int id)
    {
        toolbarController.Set(id);
        Highlight(id);
    }

    int currentSelectedTool;

    //to stop the highlight on tool and highlight new one
    public void Highlight(int id)
    {
        buttons[currentSelectedTool].Highlight(false);
        currentSelectedTool = id;
        buttons[currentSelectedTool].Highlight(true);
    }
}
