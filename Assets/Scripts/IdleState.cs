using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : BaseState
{
    public override void EnterState(StateManager state)
    {
        //Debug.Log("State: " + state.currentState);
        state.unitBehavScript.attacking = false;
        //Debug.Log(state.unitBehavScript.name +"'s HP: "+ state.unitBehavScript.hitPoint);

    }
    public override void UpdateState(StateManager state)
    {
        float percentHP = (state.unitBehavScript.maxHP / state.unitBehavScript.hitPoint);
        float randValue = Random.value;
        if (randValue < percentHP)
        {
            state.SwitchState(state.states[1]);
        }
        else
        {
            state.SwitchState(state.states[3]);
        }
    }
}
