using NUnit.Framework;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ToolHit : MonoBehaviour
{
    public virtual void Hit()
    {

    }

    public virtual bool CanBeHit(List<ResourceNodeType> canBeHit)
    {
        return true;
    }
}
