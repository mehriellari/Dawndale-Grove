using System;
using UnityEngine;

//deleted script and inheiriting it from itempanel script which was a copy of original inventory panel
//will make override so inventory buttons are click and drag but toolbar is scroll wheel select
public class InventoryPanel : ItemPanel
{
    public override void OnClick(int id)
    {
        GameManager.instance.dragAndDropController.OnClick(inventory.slots[id]);
        Show();
    }
}
