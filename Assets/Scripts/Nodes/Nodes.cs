using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum NodeStatus
{
    Success,
    Failure,
    Running
}

public abstract class Nodes
{
    protected UnitBehaviour unitBehaviour;

    // Initialize the ownerObject reference
    public virtual void Initialize(GameObject owner)
    {
        unitBehaviour = owner.GetComponent<UnitBehaviour>();
    }
    public abstract NodeStatus Execute();
}