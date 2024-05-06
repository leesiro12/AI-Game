using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : IdleState
{
    public override void EnterState(StateManager state)
    {
        Debug.Log("State: " + state.currentState);
    }
    public override void UpdateState(StateManager state)
    {

        if (state.unitBehavScript is FighterBehaviour)
        {
            FighterBehaviour behavscript = (FighterBehaviour)state.unitBehavScript;
            behavscript.StartCoroutine(behavscript.HitSth());
        }
        if (state.unitBehavScript is ArcherBehaviour)
        {
            ArcherBehaviour behavscript = (ArcherBehaviour)state.unitBehavScript;
            behavscript.StartCoroutine(behavscript.HitSth());
        }
        else
        {
            //if (state.unitBehavScript.team != state.unitBehavScript.team)
            //state.unitBehavScript.StartCoroutine(state.unitBehavScript.HitSth(state));
        }
        state.SwitchState(state.states[2]);
    }
}
