using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefState : IdleState
{
    public override void EnterState(StateManager state)
    {
        Debug.Log(state.currentState);
    }
    public override void UpdateState(StateManager state)
    {

        state.SwitchState(state.states[0]);
    }
}
