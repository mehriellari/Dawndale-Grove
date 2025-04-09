using UnityEngine;
using System.Collections.Generic;
using System.Collections;

//grouping panels
public class PanelGroup : MonoBehaviour
{
    public List<GameObject> panels;

    public void Show(int idPanel)
    {
        for(int i = 0; i < panels.Count; i++)
        {
            panels[i].SetActive(i == idPanel);
        }
    }
}
