using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitState : AttackState
{
    public override void EnterState(StateManager state)
    {
        Debug.Log("State: " + state.currentState);
        
        //Debug.Log(state.unitBehavScript.hitPoint);
    }
    public override void UpdateState(StateManager state)
    {
        
        if (state.unitBehavScript.attacking)
        {
            state.unitBehavScript.attacking = false;
            state.SwitchState(state.states[0]);
        }
        else if (!state.unitBehavScript.attacking)
        {
            state.SwitchState(state.states[0]);
        }
    }
}
