using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : BaseState
{
    public override void EnterState(StateManager state)
    {
        Debug.Log("Wah");
    }
    public override void UpdateState(StateManager state)
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            state.SwitchState(state.states[1]);
        }
    }
}
