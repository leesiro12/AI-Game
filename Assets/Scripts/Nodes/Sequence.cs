using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sequence : Nodes
{
    List<Nodes> nodes = new List<Nodes>();

    public void AddNode(Nodes node)
    {
        nodes.Add(node);
    }

    public override NodeStatus Execute()
    {
        foreach (Nodes item in nodes)
        {
            NodeStatus status = item.Execute();
            if (status != NodeStatus.Success)
            {
                return status;
            }
        }
        return NodeStatus.Success;
    }
}
