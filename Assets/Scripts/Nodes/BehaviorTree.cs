using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviorTree : Manager
{
    Selector root = new Selector();


    public override void Activate()
    {
        root.Execute();
    }


}
