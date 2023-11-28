using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : BaseState
{
    public override void EnterState(StateManager state)
    {
        //Debug.Log("State: " + state.currentState);
        Debug.Log(state.unitBehavScript.name +"'s HP: "+ state.unitBehavScript.hitPoint);
    }
    public override void UpdateState(StateManager state)
    {
        state.SwitchState(state.states[1]);
    }
}
