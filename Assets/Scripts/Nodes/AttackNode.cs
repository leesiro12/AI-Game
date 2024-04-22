using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackNode : Nodes
{
    public override NodeStatus Execute()
    {
        unitBehaviour.AttackSth();
        return NodeStatus.Running;
    }
}
