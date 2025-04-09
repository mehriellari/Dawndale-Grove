using NUnit.Framework;
using UnityEngine;
using UnityEngine.TextCore.Text;
using System.Collections;
using System.Collections.Generic;

public enum ResourceNodeType
{
    undefined,
    Crop
}

[CreateAssetMenu(menuName ="Data/Tool action/Gather Resource")]

//type of tool action
//determining the area around the player that the tool can interact with
public class GatherResource : ToolAction
{
    [SerializeField] float sizeOfInteractableArea = 0.5f;
    [SerializeField] List<ResourceNodeType> canHitNodesOfType;

    public override bool OnApply(Vector2 worldPoint)
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(worldPoint, sizeOfInteractableArea);

        foreach (Collider2D c in colliders)
        {
            ToolHit hit = c.GetComponent<ToolHit>();
            if (hit != null)
            {
                if(hit.CanBeHit(canHitNodesOfType) == true)
                {
                    hit.Hit();
                    return true;
                }
            }
        }
        return false;
    }
}
