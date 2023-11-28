using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : BaseState
{
    public override void EnterState(StateManager state)
    {
        //Debug.Log("State: " + state.currentState);
    }
    public override void UpdateState(StateManager state)
    {
        //if (state.unitBehavScript.team != state.unitBehavScript.team)
        state.unitBehavScript.StartCoroutine(state.unitBehavScript.HitSth(state));
        state.SwitchState(state.states[2]);
    }
}
