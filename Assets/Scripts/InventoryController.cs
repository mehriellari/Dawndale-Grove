using Unity.VisualScripting;
using UnityEngine;
using System;

public class InventoryController : MonoBehaviour
{
    [SerializeField] GameObject panel;
    [SerializeField] GameObject craftingPanel;
    [SerializeField] GameObject toolbarPanel;
    [SerializeField] GameObject storePanel;

    //to open or close inventory
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if(panel.activeInHierarchy == false)
            {
                Open();
            }
            else
            {
                Close();
            }
        }
    }

    //showing what UI is active when inventory is open
    public void Open()
    {
        panel.SetActive(true);
        craftingPanel.SetActive(true);
        toolbarPanel.SetActive(false);
        storePanel.SetActive(false);
    }

    //showing what UI is active when inventory is closed
    public void Close()
    {
        panel.SetActive(false);
        craftingPanel.SetActive(false);
        toolbarPanel.SetActive(true);
        storePanel.SetActive(false);
    }
}
