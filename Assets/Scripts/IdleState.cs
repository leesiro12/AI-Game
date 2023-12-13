using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : BaseState
{
    public override void EnterState(StateManager state)
    {
        //Debug.Log("State: " + state.currentState);
        Debug.Log(state.unitBehavScript.name +"'s HP: "+ state.unitBehavScript.hitPoint);
        if (state.unitBehavScript.hitPoint <= 0)
        {
            //UnitManager.instance.isPlaying = false;
            state.unitBehavScript.hitPoint = 0;
            state.unitBehavScript.slider.value = 0;
            Debug.Log(state.unitBehavScript.actualtarget.name + " died");
            state.unitBehavScript.actualtarget.gameObject.SetActive(false);
        }
    }
    public override void UpdateState(StateManager state)
    {
        
        state.SwitchState(state.states[1]);
    }
}
