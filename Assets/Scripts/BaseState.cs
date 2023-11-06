using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseState
{
    //protected GameObject gameObject;
    public abstract void EnterState(StateManager state);
    public abstract void UpdateState(StateManager state);
}
